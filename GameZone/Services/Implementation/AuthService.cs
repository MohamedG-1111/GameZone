using GameZone.Data;
using GameZone.Models;
using GameZone.Services.Interfaces;
using GameZone.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IAttachmentService attachmentService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ApplicationDbContext context;

        public AuthService(
            IAttachmentService attachmentService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            this.attachmentService = attachmentService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            if (model == null)
                return false;
            var result = await signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                true,
                false
            );
            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task LogOutAsync()
        {
            await signInManager.SignOutAsync();
        }



        public async Task<bool> RegisterAsync(RegisterationViewModel model, string Role = Roles.User)
        {
            if (model == null) return false;
            var uploadedImageUrl = await attachmentService.UploadAttachmentAsync(model.ImageUrl);

            ApplicationUser user = new ApplicationUser
            {
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Email = model.Email,
                UserName = model.Email,
                ImageUrl = uploadedImageUrl

            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Role);
                if (Role == Roles.User)
                    await signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.WriteLine(errors);
                if (!string.IsNullOrEmpty(uploadedImageUrl))
                    await attachmentService.DeleteAttachmentAsync(uploadedImageUrl);
            }




            return false;
        }


    }
}
