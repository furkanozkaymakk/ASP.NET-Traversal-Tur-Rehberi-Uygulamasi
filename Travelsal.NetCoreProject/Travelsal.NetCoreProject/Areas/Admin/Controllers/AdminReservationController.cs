using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public AdminReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult GetApprovalReservation()
        {
            var values = _reservationService.TGetApprovalReservation();
            return View(values);
        }

        public IActionResult GetOldReservation()
        {
            var values = _reservationService.TGetOldReservation();
            return View(values);
        }

        public IActionResult GetCurrentReservation()
        {
            var values = _reservationService.TGetCurrentReservation();
            return View(values);
        }
        public IActionResult ChangeToAccepted(int id)
        {
            var values = _reservationService.TGetByID(id);
            values.Status = "Onaylandı";
            _reservationService.TUpdate(values);
            return RedirectToAction("GetApprovalReservation");
        }

        public IActionResult ChangeToCancel(int id)
        {
            var values = _reservationService.TGetByID(id);
            values.Status = "İptal Edildi";
            _reservationService.TUpdate(values);
            return RedirectToAction("GetApprovalReservation");
        }
    }
}
