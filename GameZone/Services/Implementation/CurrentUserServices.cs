using System.Security.Claims;
using GameZone.Data;
using GameZone.Models;
using GameZone.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Implementation
{
    public class CurrentUserServices : ICurrentUserServices
    {
        private readonly IHttpContextAccessor iHttpContextAccessor;
        private readonly ApplicationDbContext context;

        public CurrentUserServices(IHttpContextAccessor IHttpContextAccessor, ApplicationDbContext _context)
        {
            iHttpContextAccessor = IHttpContextAccessor;
            context = _context;
        }
        private ClaimsPrincipal? User => iHttpContextAccessor.HttpContext?.User;


        public string? UserId => User?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        public string? UserEmail =>
            iHttpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.Email)?.Value;

        public async Task<ApplicationUser?> GetCurrentUserAsync()
        {
            var User = await context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            return User;
        }
    }
}

