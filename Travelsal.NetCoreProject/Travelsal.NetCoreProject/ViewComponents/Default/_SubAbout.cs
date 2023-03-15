using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());
            var degerler = subAboutManager.TGetList();
            return View(degerler); 
        }
    }
}
