using Microsoft.AspNetCore.Identity;

namespace GameZone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public bool EnabalNotifications { get; set; }

        public string? ImageUrl { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
