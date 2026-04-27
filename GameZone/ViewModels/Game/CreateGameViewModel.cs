using GameZone.Attributes;
using GameZone.Settings;

namespace GameZone.ViewModels.Game
{
    public class CreateGameViewModel : GameViewModel
    {
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxSizeAllowed(FileSettings.MaxSizeInBytes)]
        public IFormFile Cover { get; set; } = null!;

    }
}
