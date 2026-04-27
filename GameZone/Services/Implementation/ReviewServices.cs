using GameZone.Data;
using GameZone.Models;
using GameZone.Services.Interfaces;
using GameZone.ViewModels.Review;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services.Implementation
{
    public class ReviewServices : IReviewServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserServices _currentUserService;

        public ReviewServices(ApplicationDbContext context, ICurrentUserServices currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<bool> AddOrUpdateReviewAsync(ReviewViewModel model)
        {
            var userId = _currentUserService.UserId;
            var existingReview = await _context.Reviews.
                FindAsync(model.GameId, userId);
            if (existingReview != null)
            {
                existingReview.Comment = model.Comment;
                existingReview.Rating = model.Rating;
                existingReview.CreatedAt = DateTime.UtcNow;

            }
            else
            {
                var review = new Review
                {
                    GameId = model.GameId,
                    Comment = model.Comment,
                    Rating = model.Rating,
                    UserId = userId
                };
                await _context.Reviews.AddAsync(review);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<GetAllReviewsForGame?>> AllReviewsForGame(int gameId)
        {
            return await _context.Reviews
                 .AsNoTracking()
                 .Where(r => r.GameId == gameId)
                .OrderByDescending(r => r.CreatedAt)
                .Select(r => new GetAllReviewsForGame
                {
                    UserName = r.User.UserName,
                    UserImage = r.User.ImageUrl,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    CreatedAt = r.CreatedAt,
                }).ToListAsync();
        }

        public async Task<ReviewViewModel?> GetMyReviewForGame(int gameId)
        {
            var userId = _currentUserService.UserId;
            var review = await _context.Reviews
                .AsNoTracking()
                .Where(r => r.GameId == gameId && r.UserId == userId)
                .Select(r => new ReviewViewModel
                {
                    GameId = r.GameId,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    CreatedAt = r.CreatedAt

                }).FirstOrDefaultAsync(); ;
            return review;
        }
    }
}
