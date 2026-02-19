using Ecommerce.DataAccess.Implementations;
using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Ecommerce.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace Ecommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = CustomRoles.admin)]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var completedOrders = _unitOfWork.Order.GetAll(o => o.OrderStatus == Status.Shipped, "OrderItems");
            // get total order, users, products, messages
            var totalOrders = completedOrders.Count();
            var totalUsers = await _userManager.Users.CountAsync();
            var totalProducts = _unitOfWork.Product.GetAll().Count();
            var totalMessages = _unitOfWork.ContactMessage.GetAll().Count();

            // Monthly Sales (Last 12 Months)
            var startDate = DateTime.Now.AddMonths(-11);
            var orders = _unitOfWork.Order.GetAll(o => o.OrderStatus == Status.Shipped && o.OrderDate >= startDate).ToList();
            
            var monthlySales = orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new
                {
                    Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                    Total = g.Sum(o => o.Total)
                })
                .OrderBy(x => x.Date)
                .ToList();

            var salesLabels = monthlySales.Select(x => x.Date.ToString("MMM")).ToArray();
            var salesData = monthlySales.Select(x => x.Total).ToArray();

            // Daily Website Views (Last 7 Days)
            var startViewDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-6));
            var views = _unitOfWork.WebsiteView.GetAll(v => v.Date >= startViewDate).ToList();
            
            var dailyViewsLabels = views.OrderBy(v => v.Date).Select(v => v.Date.ToString("ddd")).ToArray();
            var dailyViewsData = views.OrderBy(v => v.Date).Select(v => v.Count).ToArray();

            var viewModel = new DashboardViewModel
            {
                TotalOrders = totalOrders,
                TotalUsers = totalUsers,
                TotalProducts = totalProducts,
                TotalMessages = totalMessages,
                MonthlySalesLabels = salesLabels,
                MonthlySalesData = salesData,
                DailyViewsLabels = dailyViewsLabels,
                DailyViewsData = dailyViewsData
            };
            
            return View(viewModel);
        }
    }
}
