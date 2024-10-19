using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evaluate
{
    public class RatingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RatingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostRating([FromBody] Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return Ok("Rating saved");
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetAverageRating(int productId)
        {
            var averageRating = await _context.Ratings
                .Where(r => r.ProductId == productId)
                .AverageAsync(r => r.RatingValue);

            return Ok(averageRating);
        }
    }

    public class FeedbackController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return Ok("Feedback saved");
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetFeedback(int productId)
        {
            var feedbacks = await _context.Feedbacks
                .Where(f => f.ProductId == productId)
                .ToListAsync();

            return Ok(feedbacks);
        }
    }
}
