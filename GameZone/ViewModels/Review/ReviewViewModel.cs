using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels.Review
{
    public class ReviewViewModel
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [StringLength(200, ErrorMessage = "Comment cannot exceed 200 characters.")]
        public string? Comment { get; set; } = null;


        public DateTime? CreatedAt { get; set; }


    }
}