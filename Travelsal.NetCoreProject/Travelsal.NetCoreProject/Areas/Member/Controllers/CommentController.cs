using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        [Area("Member")]
        [Route("Member/[controller]/[action]/{id?}")]
        [Route("Member/[controller]/[action]/")]
        [Authorize(Roles ="Member,Admin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
