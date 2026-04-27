using GameZone.Models;
using GameZone.ViewModels.User;

namespace GameZone.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(RegisterationViewModel model, string Role = Roles.User);
        public Task<bool> LoginAsync(LoginViewModel model);
        public Task LogOutAsync();

    }
}
