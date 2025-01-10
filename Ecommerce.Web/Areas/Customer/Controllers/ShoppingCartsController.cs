using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Utilities;

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
                _unitOfWork.ShoppingCart.Add(new ShoppingCart
                {
                    Amount = 1,
                    ProductId = productId,
                    UserId = userId
                });
            }
            _unitOfWork.Complete();
            return Json(new { success = true , message = "Product added to cart successfully." });
        }
        [HttpPost]
        public void Decrement(int productId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var shoppingCart = _unitOfWork.ShoppingCart
                .GetOne(x => x.ProductId == productId && x.UserId == userId);
            if (shoppingCart != null)
            {
                if (shoppingCart.Amount > 1)
                {
                    shoppingCart.Amount--;
                    _unitOfWork.ShoppingCart.Update(shoppingCart);
                }
                else
                    _unitOfWork.ShoppingCart.Remove(shoppingCart);
                _unitOfWork.Complete();
            }
            
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
    }
}
