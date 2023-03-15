using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class CommentController : Controller
    {
        private readonly ICommentDal _commentDal;

        public CommentController(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IActionResult Index()
        {
            var values = _commentDal.GetListCommentWithDestinationandAppUser();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var value = _commentDal.TGetByID(id);
            _commentDal.Delete(value);
            return RedirectToAction("Index", "Comment");
        }
    }
}
