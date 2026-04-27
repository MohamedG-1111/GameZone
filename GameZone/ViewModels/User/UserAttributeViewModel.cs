using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels.User
{
    public class UserAttributeViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 20 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Phone]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Phone number must be exactly 11 digits.")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;




    }
}
