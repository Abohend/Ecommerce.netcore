using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Utilities;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustomRoles.admin)]

    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllOrders()
        {
            var orders = _unitOfWork.Order.GetAll();
            return Json(new { data = orders });
        }
        public IActionResult Details(int id)
        {
            var order = _unitOfWork.Order.GetOne(o => o.Id == id, includeEntities: "OrderItems.Product");
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateOrderDetails(Order order)
        {
            var dbOrder = _unitOfWork.Order.GetOne(o => o.Id == order.Id);
            
            // Update only the fields from the form
            dbOrder!.UserName = order.UserName;
            dbOrder.Phone = order.Phone;
            dbOrder.City = order.City;
            dbOrder.Address = order.Address;
            dbOrder.Carrier = order.Carrier;
            dbOrder.TrackingNumber = order.TrackingNumber;
            
            _unitOfWork.Complete();
            return RedirectToAction("Details", new { id = order.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessOrder(int id)
        {
            var order = _unitOfWork.Order.GetOne(o => o.Id == id);
            order!.OrderStatus = Status.Processing;
            _unitOfWork.Complete();
            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShipOrder(Order order)
        {
            // Validate Carrier and TrackingNumber
            if (string.IsNullOrWhiteSpace(order.Carrier))
            {
                ModelState.AddModelError("Carrier", "Carrier is required");
            }
            if (string.IsNullOrWhiteSpace(order.TrackingNumber))
            {
                ModelState.AddModelError("TrackingNumber", "Tracking number is required");
            }
            if (!ModelState.IsValid)
            {
                // Reload the order with related entities for the view
                var dbOrder = _unitOfWork.Order.GetOne(o => o.Id == order.Id, includeEntities: "OrderItems.Product");
                // Pass ModelState errors and the order back to the view
                return View("Details", dbOrder);
            }

            // Retrieve the existing order from database to preserve all fields
            var existingOrder = _unitOfWork.Order.GetOne(o => o.Id == order.Id);
            
            // Update only shipping-related fields
            existingOrder!.OrderStatus = Status.Shipped;
            existingOrder.ShippingDate = DateTime.Now;
            existingOrder.Carrier = order.Carrier;
            existingOrder.TrackingNumber = order.TrackingNumber;

            _unitOfWork.Complete();

            return RedirectToAction("Details", new { id = order.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CancelOrder(int id)
        {
            var order = _unitOfWork.Order.GetOne(o => o.Id == id);
            if (order!.PaymentStatus == Status.Approved)
            {
                var refundOption = new RefundCreateOptions
                {
                    Reason = RefundReasons.RequestedByCustomer,
                    PaymentIntent = order.PaymentIntentId
                };

                var refundService = new RefundService(); 
                Refund refund = refundService.Create(refundOption);

                order.PaymentStatus = Status.Refunded;
            }
            else
            {
                order.PaymentStatus = Status.Cancelled;
            }
            order.OrderStatus = Status.Cancelled;
            _unitOfWork.Complete();

            return RedirectToAction("Details", new { id });
        }

    }
}
