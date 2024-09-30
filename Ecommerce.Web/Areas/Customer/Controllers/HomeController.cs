using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Mvc;

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
            var products = _unitOfWork.Product.GetAll();
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Product.GetOne(p => p.Id == id, "Category");
            return View(product);
        }
    }
}
