using BackendPRJCT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BackendPRJCT.Helpers;
using BackendPRJCT.ModelViews.Account;

namespace BackendPRJCT.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = new AppUser();
            appUser.FullName = registerVM.FullName;
            appUser.Email = registerVM.Email;
            appUser.UserName = registerVM.UserName;
            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerVM);
            }
            await _userManager.AddToRoleAsync(appUser, EnumRole.Admin.ToString());
            return RedirectToAction("login");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);

            if (user == null)
            {
                user = await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
                if (user == null)
                {
                    ModelState.AddModelError("", "UserNameOrEmail or Password Sehvdir");
                    return View(loginVM);
                }
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Hesabiniz Bloklanib");
                return View(loginVM);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "usernameoremail ve ya password sehvdir");
                return View(loginVM);
            }

            await _signInManager.SignInAsync(user, loginVM.RememberMe);


            return RedirectToAction("index", "home");

        }
    }
}
