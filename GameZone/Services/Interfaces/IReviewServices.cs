using GameZone.ViewModels.Review;

namespace GameZone.Services.Interfaces
{
    public interface IReviewServices
    {
        public Task<bool> AddOrUpdateReviewAsync(ReviewViewModel model);
        public Task<List<GetAllReviewsForGame?>> AllReviewsForGame(int gameId);

        public Task<ReviewViewModel?> GetMyReviewForGame(int gameId);

    }
}
