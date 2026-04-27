using GameZone.Services.Interfaces;
using GameZone.ViewModels.Review;
using Microsoft.AspNetCore.Mvc;

namespace GameZone.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewServices _reviewServices;

        public ReviewController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]


        public async Task<IActionResult> AddOrUpdateReview(ReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill all required fields correctly";
            }

            var success = await _reviewServices.AddOrUpdateReviewAsync(model);
            if (!success)
                return BadRequest();

            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> AllReviewsForGame(int gameId)
        {
            var reviews = await _reviewServices.AllReviewsForGame(gameId);
            if (reviews == null || reviews.Count == 0)
            {
                TempData["InfoMessage"] = "No reviews for this game yet.";
            }
            return View("GetAllReviewsForGame", reviews);

        }
    }
}
