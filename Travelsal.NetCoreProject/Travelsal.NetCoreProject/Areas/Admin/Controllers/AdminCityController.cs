using BusinessLayer.Abstract;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Travelsal.NetCoreProject.Models;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public AdminCityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            return Json(destination);
        }

        public IActionResult GetCityByID(int DestinationID)
        {
            var city = _destinationService.TGetByID(DestinationID);
            var jsonCity = JsonConvert.SerializeObject(city);
            return Json(jsonCity);
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult DeleteCityByID(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            return NoContent();
        }

    }
}
