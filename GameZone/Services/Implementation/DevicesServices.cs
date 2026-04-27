using GameZone.Data;
using GameZone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Implementation
{
    public class DevicesServices : IDevicesServices
    {
        private readonly ApplicationDbContext _context;

        public DevicesServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> Devices()
        {
            return _context.Devices.AsNoTracking().Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                .OrderBy(c => c.Text).ToList();
        }
    }
}
