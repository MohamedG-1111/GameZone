using GameZone.Data.Repositories.Interfaces;
using GameZone.Models;
using GameZone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Implementation
{
    public class DevicesServices : IDevicesServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DevicesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<SelectListItem> Devices()
        {
            return _unitOfWork.Repository<Device>().GetAsQuery().Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                .OrderBy(c => c.Text).ToList();
        }
    }
}
