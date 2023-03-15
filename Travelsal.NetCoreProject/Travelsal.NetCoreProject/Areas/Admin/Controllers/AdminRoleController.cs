using BusinessLayer.Abstract;
using DTOLayer.DTOs.RoleDTOs;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Travelsal.NetCoreProject.Areas.Admin.Controllers
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Route("Admin/[controller]/[action]/")]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRoleController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAppRoleService _appRoleService;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(IAppUserService appUserService, IAppRoleService appRoleService, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _appRoleService = appRoleService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<RoleGroupDto> list = new List<RoleGroupDto>();
            var values = _appUserService.TGetList();
            foreach (var item in values)
            {
                RoleGroupDto groupDto = new RoleGroupDto()
                {
                    UserID = item.Id,
                    UserName = item.UserName,
                    Role = _appRoleService.TGetRoleID(item.Id)
                };
                list.Add(groupDto);
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRole(int id)
        {
            var user = _userManager.Users.Where(x => x.Id == id).FirstOrDefault();
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);
            RoleGroupDto model = new RoleGroupDto();

            foreach (var item in roles)
            {
                if(userRoles.Contains(item.Name))
                {
                    model.Role = item.Name;
                    model.UserID = item.Id;
                }
            }
            TempData["rolList"] = model.Role;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleGroupDto rol)
        {
            var userid = (int)TempData["UserId"];
            var roles = _roleManager.Roles.ToList();
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==userid);

            foreach(var item in roles)
            {
                await _userManager.RemoveFromRoleAsync(user,item.Name);
            }
            await _userManager.AddToRoleAsync(user, rol.Role);
            return RedirectToAction("Index");
        }
    }
}
