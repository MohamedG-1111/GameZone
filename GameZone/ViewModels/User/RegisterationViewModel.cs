using System.ComponentModel.DataAnnotations;
using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.ViewModels.User
{
    public class RegisterationViewModel : UserAttributeViewModel
    {


        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{6,}$",
        ErrorMessage = "Password must contain uppercase, lowercase, number, and special character.")]
        public string Password { get; set; } = string.Empty;

        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxSizeAllowed(FileSettings.MaxSizeInBytes)]
        public IFormFile? ImageUrl { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "CheckEmail", controller: "Account", HttpMethod = "Get", ErrorMessage = "Email already exists")]
        public string Email { get; set; } = string.Empty;

    }
}
