using Microsoft.AspNetCore.Mvc;
using ReviewService.ApplicationCore.Models;
using ReviewService.ApplicationCore.Services;
using System.ComponentModel;

namespace ReviewService.API.Controllers
{
    public class CustomerReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;


        public CustomerReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("CustomerReview")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviews();
            return Ok(reviews);
        }

        [HttpPost("CustomerReview")]
        public IActionResult CreateReview(CustomerReviewRequestModel model)
        {
            return Ok(1);
        }

        [HttpPut("CustomerReview")]
        public IActionResult UpdateReview() {
            // The API specification includes a PUT endpoint on the collection root ('/api/CustomerReview') without an ID.
            // This is unconventional, and its intended purpose (e.g., bulk update) is unclear.
            // Awaiting clarification on the requirements before implementing.
            return Ok(1);
        }

    }
}
