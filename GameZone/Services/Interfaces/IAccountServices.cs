using GameZone.ViewModels.User;

namespace GameZone.Services.Interfaces
{
    public interface IAccountServices
    {
        public Task<bool> CheckEmail(string Email);
        public Task<bool> CreateAdmin(RegisterationViewModel model);

        public Task<AccountViewModel> GetAccountDetails();
        public Task<bool> EditProfileImage(EditProfileImageViewModel model);
        public Task<bool> EditProfile(EditAccountViewModel model);
        public Task<EditAccountViewModel> GetProfileToEdit();

    }
}
