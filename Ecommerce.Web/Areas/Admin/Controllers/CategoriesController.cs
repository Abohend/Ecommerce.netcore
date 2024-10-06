using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustomRoles.admin)]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Complete();
                TempData["toast"] = "Category has been created sucessfully";
                TempData["toastType"] = "success";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_unitOfWork.Category.GetOne(c => c.Id == id));
        }

        [ValidateAntiForgeryToken, HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Complete();
                TempData["toast"] = "Category has been updated sucessfully";
                TempData["toastType"] = "info";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_unitOfWork.Category.GetOne(c => c.Id == id));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Complete();
            TempData["toast"] = "Category has been deleted sucessfully";
            TempData["toastType"] = "danger";
            return RedirectToAction("Index");
        }
    }
}
