using Ecommerce.Entities.Models;
using Ecommerce.Entities.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Utilities;
using System;

namespace Ecommerce.Web.Filters
{
    public class WebsiteViewCounterFilter : IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public WebsiteViewCounterFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do nothing
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Logic to log view
            // Check if user is Admin
            // We only want to count page views (GET requests usually)
            if (context.HttpContext.User.IsInRole(CustomRoles.admin) || context.HttpContext.Request.Method != "GET")
            {
                return;
            }

            try 
            {
                var today = DateOnly.FromDateTime(DateTime.Now);
                var viewRecord = _unitOfWork.WebsiteView.GetOne(u => u.Date == today);

                if (viewRecord == null)
                {
                    viewRecord = new WebsiteView
                    {
                        Date = today,
                        Count = 1
                    };
                    _unitOfWork.WebsiteView.Add(viewRecord);
                }
                else
                {
                    viewRecord.Count += 1;
                    _unitOfWork.WebsiteView.Update(viewRecord);
                }
                _unitOfWork.Complete();
            }
            catch
            {
                // Silently fail to not block the user navigation?
            }
        }
    }
}
