using GameZone.Models;

namespace GameZone.Services.Interfaces
{
    public interface ICurrentUserServices
    {
        public string? UserId { get; }
        public string? UserEmail { get; }
        public Task<ApplicationUser?> GetCurrentUserAsync();
    }
}
