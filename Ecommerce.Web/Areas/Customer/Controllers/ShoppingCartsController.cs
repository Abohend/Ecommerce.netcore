using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using SessionCreateOptions = Stripe.Checkout.SessionCreateOptions;
using SessionService = Stripe.Checkout.SessionService;
using Session = Stripe.Checkout.Session;
using System.Security.Claims;
using Utilities;
using Ecommerce.Entities.ViewModels;

namespace Ecommerce.Web.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class ShoppingCartsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var shoppingCarts = _unitOfWork.ShoppingCart.GetAll(x => x.UserId == userId, includeEntities: "Product");
            ViewBag.Total = shoppingCarts.Sum(p => p.Amount * p.Product!.Price);
            return View(shoppingCarts);
        }

        [HttpGet]
        public IActionResult GetCartCount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var carts = _unitOfWork.ShoppingCart.GetAll(x => x.UserId == userId);
            var cartCount = carts.Sum(p => p.Amount);
            return Json(cartCount);
        }

        [HttpGet]
        public IActionResult GetUserCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var shoppingCarts = _unitOfWork.ShoppingCart.GetAll(x => x.UserId == userId);
            var cartData = shoppingCarts.ToDictionary(k => k.ProductId, v => v.Amount);
            return Json(cartData);
        }

        [HttpPost]
        public IActionResult Increment(int productId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var shoppingCart = _unitOfWork.ShoppingCart
                .GetOne(x => x.ProductId == productId && x.UserId == userId);
            if (shoppingCart != null)
            {
                shoppingCart.Amount++;
                _unitOfWork.ShoppingCart.Update(shoppingCart);
            }
            else
            {
                shoppingCart = new ShoppingCartItem
                {
                    Amount = 1,
                    ProductId = productId,
                    UserId = userId
                };
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }
            _unitOfWork.Complete();
            return Json(new { success = true, newAmount = shoppingCart.Amount, message = "Product added/incremented successfully." });
        }
        
        [HttpPost]
        public IActionResult Decrement(int productId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var shoppingCart = _unitOfWork.ShoppingCart
                .GetOne(x => x.ProductId == productId && x.UserId == userId);
            
            uint newAmount = 0;
            if (shoppingCart != null)
            {
                if (shoppingCart.Amount > 1)
                {
                    shoppingCart.Amount--;
                    newAmount = shoppingCart.Amount;
                    _unitOfWork.ShoppingCart.Update(shoppingCart);
                }
                else
                {
                    _unitOfWork.ShoppingCart.Remove(shoppingCart);
                    newAmount = 0;
                }
                _unitOfWork.Complete();
            }
            return Json(new { success = true, newAmount = newAmount, message = "Product decremented successfully." });
        }
        
        [HttpPost]
        public void Remove(int productId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var shoppingCart = _unitOfWork.ShoppingCart
                .GetOne(x => x.ProductId == productId && x.UserId == userId);
            if (shoppingCart != null)
            {
                _unitOfWork.ShoppingCart.Remove(shoppingCart);
                _unitOfWork.Complete();
            }
        }
        
        [HttpGet]
        public IActionResult Checkout()
        {
            var checkoutVM = new CheckoutVM();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            checkoutVM.ShoppingCartItems = _unitOfWork.ShoppingCart.GetAll(x => x.UserId == userId, includeEntities: "Product");
            
            checkoutVM.Total= checkoutVM.ShoppingCartItems.Sum(p => p.Amount * p.Product!.Price);
            
            return View(checkoutVM);
        }
        
        [HttpPost]
        public IActionResult Checkout(CheckoutVM checkoutVM)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            checkoutVM.ShoppingCartItems = _unitOfWork.ShoppingCart.GetAll(x => x.UserId == userId, includeEntities: "Product");
            checkoutVM.Total = checkoutVM.ShoppingCartItems.Sum(p => p.Amount * p.Product!.Price);
            
            if (!ModelState.IsValid)
            {
                return View(checkoutVM);
            }

            var order = new Order()
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!,
                OrderDate = DateTime.Now,
                OrderStatus = Status.Pending,
                PaymentStatus = Status.Pending,
                Total = checkoutVM.Total,
                UserName = checkoutVM.Name,
                Address = checkoutVM.Address,
                City = checkoutVM.City,
                Phone = checkoutVM.Phone,
                OrderItems = checkoutVM.ShoppingCartItems.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Product = i.Product,
                    Price = i.Product!.Price,
                    Amount = i.Amount
                }).ToList()
            };

            _unitOfWork.Order.Add(order);
            _unitOfWork.Complete();

            var domain = "https://localhost:44324/";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"Customer/ShoppingCarts/CheckoutSuccess?orderId={order.Id}",
                CancelUrl = domain + $"Customer/ShoppingCarts/index",
            };

            foreach (var item in order.OrderItems!)
            {
                var sessionLineOption = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Product!.Price * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.Name
                        }
                    },
                    Quantity = item.Amount
                };
                options.LineItems.Add(sessionLineOption);
            }

            var service = new SessionService();
            Session session = service.Create(options);
            
            order.SessionId = session.Id;
            order.PaymentIntentId = session.PaymentIntentId;

            _unitOfWork.Order.Update(order);
            _unitOfWork.Complete();

            Response.Headers.Append("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult CheckoutSuccess(int orderId)
        {
            var order = _unitOfWork.Order.GetOne(x => x.Id == orderId, "OrderItems");
            var session = new SessionService().Get(order!.SessionId);
            if (session.PaymentStatus.ToLower() == "paid")
            {
                order.OrderStatus = Status.Approved;
                order.PaymentStatus = Status.Approved;
                order.PaymentIntentId = session.PaymentIntentId;
            }
            var shoppingCartItems = _unitOfWork.ShoppingCart.GetAll(x => x.UserId == order.UserId, includeEntities: "Product");
            _unitOfWork.ShoppingCart.RemoveRange(shoppingCartItems);
            _unitOfWork.Complete();
            return View(orderId);
        }
        
    }
}
