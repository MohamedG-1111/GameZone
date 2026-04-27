using GameZone.Data;
using GameZone.Models;
using GameZone.Services.Interfaces;
using GameZone.ViewModels.User;
using Microsoft.EntityFrameworkCore;
namespace GameZone.Services.Implementation
{
    public class AccountServices : IAccountServices
    {
        private readonly ApplicationDbContext context;
        private readonly IAuthService authService;
        private readonly ICurrentUserServices currentUserServices;
        private readonly IAttachmentService iAttachmentService;


        public AccountServices(ApplicationDbContext _Context, IAuthService AuthService,
            ICurrentUserServices CurrentUserServices, IAttachmentService iAttachmentService)
        {
            context = _Context;
            authService = AuthService;
            currentUserServices = CurrentUserServices;
            this.iAttachmentService = iAttachmentService;

        }
        public async Task<bool> CheckEmail(string Email)
        {
            return await context.Users.AnyAsync(u =>
                  u.Email.ToLower() == Email.ToLower());
        }

        public async Task<bool> CreateAdmin(RegisterationViewModel model)
        {
            return await authService.RegisterAsync(model, Roles.Admin);
        }

        public async Task<bool> EditProfile(EditAccountViewModel model)
        {
            var User = await currentUserServices.GetCurrentUserAsync();
            if (User == null)
                return false;
            if (model == null)
                return false;
            User.FullName = string.IsNullOrEmpty(model.FullName) ? User.FullName : model.FullName;
            User.PhoneNumber = string.IsNullOrEmpty(model.PhoneNumber) ? User.PhoneNumber : model.PhoneNumber;
            User.Address = string.IsNullOrEmpty(model.Address) ? User.Address : model.Address;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditProfileImage(EditProfileImageViewModel model)
        {
            var Id = currentUserServices.UserId;
            if (string.IsNullOrEmpty(Id))
                return false;
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == Id);
            if (user == null) return false;
            if (model.ImageUrl != null)
            {
                var OldImage = user.ImageUrl;

                var result = await iAttachmentService.UploadAttachmentAsync(model.ImageUrl);
                if (result != null)
                {
                    user.ImageUrl = result;
                    await context.SaveChangesAsync();
                    if (!string.IsNullOrEmpty(OldImage))
                    {
                        await iAttachmentService.DeleteAttachmentAsync(OldImage);
                    }
                    return true;
                }
            }
            return false;

        }

        public async Task<AccountViewModel> GetAccountDetails()
        {
            var CurrentUser = currentUserServices.UserId;
            if (CurrentUser == null)
                return null;
            var User = await context.Users.FirstOrDefaultAsync(u => u.Id == CurrentUser);
            if (User == null)
                return null;
            return new AccountViewModel
            {
                UserId = User.Id,
                FullName = User.FullName,
                Email = User.Email,
                PhoneNumber = User.PhoneNumber,
                ExistingImageUrl = User.ImageUrl,
                Address = User.Address,
            };

        }

        public async Task<EditAccountViewModel> GetProfileToEdit()
        {
            var CurrentUser = await currentUserServices.GetCurrentUserAsync();
            if (CurrentUser == null)
                return null;
            return new EditAccountViewModel
            {
                FullName = CurrentUser.FullName,
                PhoneNumber = CurrentUser.PhoneNumber,
                Address = CurrentUser.Address,
            };
        }
    }
}
