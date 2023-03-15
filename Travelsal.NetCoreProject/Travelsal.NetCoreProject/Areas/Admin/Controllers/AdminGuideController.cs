using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Entity;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Authorize(Roles = "Admin")]
    public class AdminGuideController : Controller
    {
        private readonly IGuideService _guideService;

        public AdminGuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuide(GuideViewDto guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            string imagenameString="";

            if (guide.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(guide.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await guide.Image.CopyToAsync(stream);
                imagenameString = "/userimages/" + imagename;
            }
            var guideNew = new Guide() { Image = imagenameString, Description = guide.Description, InstagramUrl = guide.InstagramUrl, Name = guide.Name, Status = false, TwitterUrl = guide.TwitterUrl, };
            if (result.IsValid)
            {
                _guideService.TAdd(guideNew);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            GuideViewDto guideView = new GuideViewDto()
            {
                Name = values.Name,
                Description = values.Description,
                TwitterUrl = values.TwitterUrl,
                InstagramUrl = values.InstagramUrl,
                ID= id
            };
            return View(guideView);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuide(GuideViewDto guide)
        {
            var values = _guideService.TGetByID(guide.ID);
            if (guide.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(guide.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await guide.Image.CopyToAsync(stream);
                values.Image = "/userimages/" + imagename;
            }
            values.Description = guide.Description;
            values.TwitterUrl = guide.TwitterUrl;
            values.InstagramUrl = guide.InstagramUrl;
            values.Name= guide.Name;
            _guideService.TUpdate(values);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index");
        }
    }
}
