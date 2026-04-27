using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.ViewModels.Game
{
    public class GameViewModel
    {
        [Required]
        [MaxLength(250)]
        [Remote(action: "CheckName", controller: "Games", ErrorMessage = "Name Must be Unique")] public string Name { get; set; } = null!;

        [MaxLength(2500)]
        [Required]
        public string Description { get; set; } = null!;


        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Devices")]
        [Required]
        public List<int> SelectedDevices { get; set; } = [];

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
