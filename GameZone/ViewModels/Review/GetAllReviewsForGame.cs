namespace GameZone.ViewModels.Review
{
    public class GetAllReviewsForGame
    {
        public string UserName { get; set; }
        public string UserImage { get; set; }

        public string? Comment { get; set; }

        public int Rating { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
