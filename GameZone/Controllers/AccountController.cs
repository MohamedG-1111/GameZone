using GameZone.Models;
using GameZone.Services.Interfaces;
using GameZone.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;


        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }
        [HttpGet]
        public async Task<IActionResult> CheckEmail(string Email)
        {
            var IsExisted = await _accountServices.CheckEmail(Email);
            return Json(!IsExisted);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddAdmin(RegisterationViewModel model)
        {
            var Sucess = await _accountServices.CreateAdmin(model);
            if (Sucess)
                TempData["Success"] = "Admin Created Successfully";
            else
                TempData["Error"] = "Something went wrong, Please try again later";
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = $"{Roles.Admin},{Roles.User}")]
        public async Task<IActionResult> Profile()
        {
            var AccountDetails = await _accountServices.GetAccountDetails();
            if (AccountDetails == null)
                return NotFound();
            return View(AccountDetails);

        }
        public async Task<IActionResult> EditProfileImage(EditProfileImageViewModel model)
        {
            var Sucess = await _accountServices.EditProfileImage(model);
            if (Sucess)
                TempData["Success"] = "Profile Image Updated Successfully";
            else
                TempData["Error"] = "Something went wrong, Please try again later";
            return RedirectToAction("Profile");

        }
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var model = await _accountServices.GetProfileToEdit();
            if (model == null)
                return NotFound();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditAccountViewModel model)
        {
            var Sucess = await _accountServices.EditProfile(model);
            if (Sucess)
                TempData["Success"] = "Profile Updated Successfully";
            else
                TempData["Error"] = "Something went wrong, Please try again later";
            return RedirectToAction("Profile");

        }
    }
}
