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

        [HttpGet("api/CustomerReview")]
        public async Task<IActionResult> GetMyReview(int OrderId, int CustId)
        {
            var review = await _reviewService.GetMyReviews(OrderId, CustId);
            if (review != null)
            {
                return Ok(review);
            }
            return NotFound($"No review found for Order ID {OrderId} and Customer ID {CustId}.");
        }

        [HttpPost("api/CustomerReview")]
        public IActionResult CreateReview(CustomerReviewRequestModel model)
        {
            var res = _reviewService.CreateReview(model, model.OrderId);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("Failed to create review.");
        }

        [HttpPut("api/CustomerReview")]
        public IActionResult UpdateReview(CustomerReviewRequestModel model, int id)
        {
            var res = _reviewService.UpdateReview(model, id);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("Failed to update review.");
        }

        [HttpDelete("api/CustomerReview/delete-{id}")]
        public IActionResult DeleteReview(int id)
        {
            var res = _reviewService.DeleteReview(id);
            if (res != null)
            {
                return Ok($"Review with ID {id} deleted successfully.");
            }
            return NotFound($"Review with ID {id} not found.");
        }

        [HttpGet("api/CustomerReview/{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewById(id);
            if (review != null)
            {
                return Ok(review);
            }
            return NotFound($"Review with ID {id} not found.");
        }

        [HttpGet("api/CustomerReview/user/{userId}")]
        public async Task<IActionResult> GetReviewsByUserId(int userId)
        {
            var reviews = await _reviewService.GetReviewsByUserId(userId);
            if (reviews != null && reviews.Any())
            {
                return Ok(reviews);
            }
            return NotFound($"No reviews found for user ID {userId}.");

        }

        [HttpGet("api/CustomerReview/product/{productId}")]
        public async Task<IActionResult> GetReviewsByProductId(int productId)
        {
            var reviews = await _reviewService.GetReviewsByProductId(productId);
            if (reviews != null && reviews.Any())
            {
                return Ok(reviews);
            }
            return NotFound($"No reviews found for product ID {productId}.");
        }


        [HttpGet("api/CustomerReview/year/{year}")]
        public async Task<IActionResult> GetReviewsByYear(DateTime year)
        {

            var reviews = await _reviewService.GetReviewsByYear(year);
            if (reviews != null && reviews.Any())
            {
                return Ok(reviews);
            }
            return NotFound($"No reviews found for the year {year}.");
        }

        [HttpPut("api/CustomerReview/approve/{id}")]
        public async Task<IActionResult> ApproveReview(int id)
        {
            var result = await _reviewService.ApproveReview(id);
            if (result != null)
            {
                return Ok($"Review with ID {id} approved successfully.");
            }
            return NotFound($"Review with ID {id} not found or already approved.");
        }

        [HttpPut("api/CustomerReview/reject/{id}")]
        public async Task<IActionResult> RejectReview(int id)
        {
            var result = await _reviewService.RejectReview(id);
            if (result != null)
            {
                return Ok($"Review with ID {id} rejected successfully.");
            }
            return NotFound($"Review with ID {id} not found or already rejected.");
        }
    }
}
