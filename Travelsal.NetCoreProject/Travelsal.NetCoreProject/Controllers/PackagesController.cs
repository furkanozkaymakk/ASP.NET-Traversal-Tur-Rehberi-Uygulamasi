using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IDestinationService _destinationService;

        public PackagesController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
    }
}
