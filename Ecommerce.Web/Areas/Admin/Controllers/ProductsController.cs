using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Ecommerce.Entities.ViewModels;
using Ecommerce.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utilities;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustomRoles.admin)]

    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly FileService _fileService;

        public ProductsController(IUnitOfWork unitOfWork
            , IWebHostEnvironment webHostEnvironment
            , FileService fileService)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }        
        
        [HttpGet]
        public IActionResult GetAllData()
        {
            var products = _unitOfWork.Product.GetAll(includeEntities:"Category");
            return Json(new { data = products });
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductCategoriesVM productVM = new ProductCategoriesVM()
            {
                Product = new Product(),
                Categories = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(productVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategoriesVM productVM, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    productVM.Product.Image = _fileService.UploadFile("images/products", file);
                }
                _unitOfWork.Product.Add(productVM.Product);
                _unitOfWork.Complete();
                TempData["toast"] = "Product has been created successfully";
                TempData["toastType"] = "success";
                return RedirectToAction("Index");
            }
            productVM.Categories = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
            return View(productVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.Product.GetOne(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ProductCategoriesVM productVM = new ProductCategoriesVM()
            {
                Product = product,
                Categories = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            return View(productVM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategoriesVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    _fileService.DeleteFile(productVM.Product.Image);
                    productVM.Product.Image = _fileService.UploadFile("images/products", file);
                }
                _unitOfWork.Product.Update(productVM.Product);
                _unitOfWork.Complete();
                TempData["toast"] = "Product has been updated successfully";
                TempData["toastType"] = "info";
                return RedirectToAction("Index");
            }
            return View(productVM);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Product.GetOne(p => p.Id == id);
            if (product == null)
            {
                return Json(new { success = false });
            }
            _fileService.DeleteFile(product.Image);
            _unitOfWork.Product.Remove(product);
            _unitOfWork.Complete();
            return Json(new {success = true});
        }
    }
}
