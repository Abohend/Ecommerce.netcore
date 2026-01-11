using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustomRoles.admin)]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var messages = _unitOfWork.ContactMessage.GetAll().OrderByDescending(m => m.CreatedDate);
            return View(messages);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var message = _unitOfWork.ContactMessage.GetOne(model => model.Id == id);
            if (message == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.ContactMessage.Remove(message);
            _unitOfWork.Complete();
            return Json(new { success = true, message = "Delete Successful" });
        }

        [HttpGet]
        public IActionResult Info()
        {
            var contactInfo = _unitOfWork.ContactInfo.GetAll().FirstOrDefault();
            if (contactInfo == null)
            {
                contactInfo = new ContactInfo();
            }
            return View(contactInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Info(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                if (contactInfo.Id == 0)
                {
                    _unitOfWork.ContactInfo.Add(contactInfo);
                }
                else
                {
                    _unitOfWork.ContactInfo.Update(contactInfo);
                }
                _unitOfWork.Complete();
                TempData["Success"] = "Contact Info Updated Successfully";
                return RedirectToAction(nameof(Info));
            }
            return View(contactInfo);
        }
    }
}
