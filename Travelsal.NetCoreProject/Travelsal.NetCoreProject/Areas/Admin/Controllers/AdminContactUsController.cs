using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public AdminContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            var values = _contactUsService.TGetList();
            return View(values);
        }

        public IActionResult ContactUsOrderByFirstReaded()
        {
            var values = _contactUsService.TGetListContactUsOrderByFirstRead();
            return RedirectToAction("Index",new {values});
        }

        public IActionResult ReadContactUs(int id)
        {
            var values = _contactUsService.TGetByID(id);
            values.MessageStatus = true;
            _contactUsService.TUpdate(values);
            return View(values);
        }
    }
}
