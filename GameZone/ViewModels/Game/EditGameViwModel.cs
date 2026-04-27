using GameZone.Attributes;
using GameZone.Settings;

namespace GameZone.ViewModels.Game
{
    public class EditGameViwModel : GameViewModel
    {

        public string? ExistingCover { get; set; }

        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxSizeAllowed(FileSettings.MaxSizeInBytes)]
        public IFormFile? Cover { get; set; }
    }
}
