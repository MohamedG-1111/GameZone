using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Interfaces
{
    public interface IDevicesServices
    {
        public IEnumerable<SelectListItem> Devices();
    }
}
