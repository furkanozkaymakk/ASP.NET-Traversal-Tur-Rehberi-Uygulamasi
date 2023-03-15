using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Travelsal.NetCoreProject.Models;

namespace Travelsal.NetCoreProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _sigInManager;


        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> sigInManager)
        {
            _userManager = userManager;
            _sigInManager = sigInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                UserName = p.Username,
                Name = p.Name,
                Email = p.Mail,
                Surname = p.Surname
            };
            if(p.Password==p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser,p.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
            }

            return View(p);

        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            if(ModelState.IsValid)
            {
                var result = await _sigInManager.PasswordSignInAsync(p.Username,p.Password,false,true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Default");
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {

            await _sigInManager.SignOutAsync();
            return RedirectToAction("SignIn", "Login");
        }

        public IActionResult AccessDeniedd()
        {
            return View();
        }
    }
}
