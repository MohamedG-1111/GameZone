using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Interfaces
{
    public interface ICategoryServices
    {
        IEnumerable<SelectListItem> Categories();
    }
}
