using Ecommerce.DataAccess.Implementations;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllData()
        {
            var users = _userManager.Users.ToList();
            var userList = new List<object>();
            
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault() ?? "No Role";
                
                userList.Add(new
                {
                    id = user.Id,
                    name = user.Name,
                    email = user.Email,
                    role,
                    lockoutEnabled = user.LockoutEnabled,
                    lockoutEnd = user.LockoutEnd
                });
            }
            
            return Json(new { data = userList });
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
                    user.LockoutEnabled = true;
                    user.LockoutEnd = DateTime.Now.AddYears(1000);
                }
                await _userManager.UpdateAsync(user);
            }            
        }
    }
}
