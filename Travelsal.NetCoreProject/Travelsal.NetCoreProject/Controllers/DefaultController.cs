using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Controllers
{
    public class DefaultController : Controller
    {
        


        public IActionResult Index()
        {
            return View();
        }
    }
}
