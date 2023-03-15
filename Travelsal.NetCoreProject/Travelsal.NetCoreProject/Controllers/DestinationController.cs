using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var degerler = _destinationService.TGetList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            ViewBag.i = id;
            var degerler = _destinationService.TGetByIdWithGuide(id);
            return View(degerler);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination d)
        {
            return View(d);
        }
    }
}
