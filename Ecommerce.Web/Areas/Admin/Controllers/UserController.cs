using Ecommerce.DataAccess.Implementations;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Utilities;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = CustomRoles.admin)]
    [Area("Admin")] 
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllData()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var users = _userManager.Users.Where(x => x.Id != id);
            return Json(new {data = users});
        }

        [HttpPost]
        public async Task LockUnlock(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (await _userManager.IsLockedOutAsync(user))
                {
                    user.LockoutEnd = null;
                }
                else
                {
                    user.LockoutEnd = DateTime.Now.AddYears(1000);
                }
                await _userManager.UpdateAsync(user);
            }            
        }
    }
}
