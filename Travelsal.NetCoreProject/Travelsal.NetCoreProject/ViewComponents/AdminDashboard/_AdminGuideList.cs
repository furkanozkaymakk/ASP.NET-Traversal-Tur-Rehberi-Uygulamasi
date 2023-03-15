using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.ViewComponents.AdminDashboard
{
    public class _AdminGuideList :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
