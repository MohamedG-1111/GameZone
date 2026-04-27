using GameZone.ViewModels.Review;

namespace GameZone.ViewModels.Game
{
    public class GetGameDetails
    {
        public int GameId { get; set; }

        public string Name { get; set; } = null!;


        public string Description { get; set; } = null!;

        public string Cover { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public List<string> DeviceNames { get; set; } = new List<string>();

        public ReviewViewModel? UserReview { get; set; }
        public double AverageRating { get; set; }
        public int AverageCount { get; set; }
    }
}
