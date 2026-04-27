using GameZone.Services.Interfaces;
using GameZone.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService iAuthServices;


        public AuthController(IAuthService IAuthServices)
        {
            iAuthServices = IAuthServices;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var Sucess = await iAuthServices.RegisterAsync(model);
            if (Sucess)
                TempData["Success"] = "Your Account Created Successfully";
            else
                TempData["Error"] = "Something went wrong, Please try again later";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await iAuthServices.LoginAsync(model);

            if (success)
                TempData["Success"] = "Login successful";
            else
                TempData["Error"] = "Invalid email or password";
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await iAuthServices.LogOutAsync();
            TempData["Success"] = "Logout successful";
            return RedirectToAction("Index", "Home");
        }

    }
}
