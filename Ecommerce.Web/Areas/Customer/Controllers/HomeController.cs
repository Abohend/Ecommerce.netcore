using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll(includeEntities: "Category");
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Product.GetOne(p => p.Id == id, "Category");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var shoppingCart = _unitOfWork.ShoppingCart.GetOne(x => x.ProductId == id && x.UserId == userId);
            ViewBag.Amount = (shoppingCart == null) ? 0 : shoppingCart.Amount;
            return View(product);
        }
    }
}
