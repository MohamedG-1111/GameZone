namespace GameZone.ViewModels.User
{
    public class AccountViewModel : UserAttributeViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string? ExistingImageUrl { get; set; }
        public IFormFile? ImageUrl { get; set; }

        public string Email { get; set; } = string.Empty;


    }
}
