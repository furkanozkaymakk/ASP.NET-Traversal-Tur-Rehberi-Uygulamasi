using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationDal _destinationDal;

        public DestinationController(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public IActionResult Index()
        {
            var values = _destinationDal.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationDal.Insert(destination);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationDal.TGetByID(id);
            _destinationDal.Delete(values);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationDal.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationDal.Update(destination);
            return RedirectToAction("Index");
        }
    }
}
