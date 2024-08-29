using Ecommerce.Web.Data;
using Ecommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly Context _context;

        public CategoriesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
		{
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
				_context.SaveChanges();
                TempData["toast"] = "Category has been created sucessfully";
                TempData["toastType"] = "success";
                return RedirectToAction("Index");
            }
            return View(category);
        }

		[HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.Categories.Find(id));
		}

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
			{
				_context.Update(category);
				_context.SaveChanges();
                TempData["toast"] = "Category has been updated sucessfully";
                TempData["toastType"] = "info";
                return RedirectToAction("Index");
			}
			return View(category);
		}

        [HttpGet]
        public IActionResult Delete(int id)
		{
			return View(_context.Categories.Find(id));
		}
        [HttpPost]
		public IActionResult Delete(Category category)
		{
			_context.Remove(category);
			_context.SaveChanges();
            TempData["toast"] = "Category has been deleted sucessfully";
            TempData["toastType"] = "danger";
            return RedirectToAction("Index");
		}
	}
}
