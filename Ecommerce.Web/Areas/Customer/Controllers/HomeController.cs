using AutoMapper;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Ecommerce.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;
using X.PagedList.Extensions;

namespace Ecommerce.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }

        public IActionResult Contact()
        {
            var contactInfo = _unitOfWork.ContactInfo.GetAll().FirstOrDefault();
            return View(contactInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactMessage msg)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ContactMessage.Add(msg);
                _unitOfWork.Complete();
                TempData["Success"] = "Message Sent Successfully";
                return RedirectToAction(nameof(Contact));
            }
            // Reload contact info if validation failed
            var contactInfo = _unitOfWork.ContactInfo.GetAll().FirstOrDefault();
            // We need to pass both the message (for validation errors) and info to the view.
            // A ViewModel would be cleaner, but using ViewBag for Info is quick.
            ViewBag.ContactInfo = contactInfo;
            // Return view with the message object to show validation errors
            return View(msg);
        }
    }
}
