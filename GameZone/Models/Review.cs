namespace GameZone.Models
{

    public class Review
    {
        public int GameId { get; set; }
        public Game Game { get; set; } = null;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; } = null;

        public int Rating { get; set; }

        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
