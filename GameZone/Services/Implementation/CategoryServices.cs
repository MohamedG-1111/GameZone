using GameZone.Data.Repositories.Interfaces;
using GameZone.Models;
using GameZone.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services.Implementation
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SelectListItem> Categories()
        {
            return _unitOfWork.Repository<Category>().GetAsQuery().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).OrderBy(c => c.Text).ToList();
        }
    }
}
