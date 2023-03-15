using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
