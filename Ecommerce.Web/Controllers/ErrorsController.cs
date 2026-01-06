using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("errors/404")]
        public IActionResult NotFound404()
        {
            return View();
        }
    }
}
