using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {
        private readonly IAppUserDal _appUserDal;
        private readonly IReservationService _reservationService;
        private readonly ICommentService _commentService;

        public AdminUserController(IAppUserDal appUserDal, IReservationService reservationService, ICommentService commentService)
        {
            _appUserDal = appUserDal;
            _reservationService = reservationService;
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _appUserDal.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var values = _appUserDal.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateUser(AppUser p)
        {
            _appUserDal.Update(p);
            return RedirectToAction("Index", "AdminUser");
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appUserDal.TGetByID(id);
            _appUserDal.Delete(values);
            return RedirectToAction("Index", "AdminUser");
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(AppUser user)
        {
            _appUserDal.Insert(user);
            return View();
        }

        public IActionResult UserComment(int id)
        {
            var personName = _appUserDal.TGetByID(id);
            ViewBag.PersonName = personName.Name;
            var values = _commentService.TGetListUserComment(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateUserComment(int id)
        {
            var values = _commentService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateUserComment(Comment comment)
        {
            _commentService.TUpdate(comment);
            return RedirectToAction("UserComment", new {id = comment.AppUserID});
        }

        public IActionResult DeleteUserComment(int id)
        {
            var values = _commentService.TGetByID(id);
            _commentService.TDelete(values);
            return RedirectToAction("UserComment", new { id = values.AppUserID });
        }

        public IActionResult UserReservation(int id)
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
