using ReviewService.ApplicationCore.Models;
using ReviewService.ApplicationCore.Repositories;
using ReviewService.ApplicationCore.Services;
using ReviewService.ApplicationCore.Entities;

namespace ReviewService.Infrastructure.Services
{
    public class CustomerReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public CustomerReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<CustomerReviewViewModel> ApproveReview(int reviewId)
        {
            var res =  await _reviewRepository.GetById(reviewId);
            if (res == null)
            {
                return null;
            }
            return ReviewEntityToModel(res);

        }

        public async Task<CustomerReviewViewModel> CreateReview(CustomerReviewRequestModel model, int orderId)
        {
            CustomerReview newRevew = new CustomerReview
            {
                CustomerName = model.CustomerName,
                OrderId = orderId,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Comment = model.Comment,
                ReviewDate = DateTime.UtcNow,
                OrderDate = DateTime.Now,
                RatingValue = model.RatingValue
            };
            var res = await _reviewRepository.Insert(newRevew);
            if (res == null)
            {
                return null;
            }
            return ReviewEntityToModel(res);

        }

        public async Task<CustomerReviewViewModel> DeleteReview(int reviewId)
        {
            var result = await _reviewRepository.DeleteById(reviewId);
            if (result == null)
            {
                return null;
            }
            return ReviewEntityToModel(result);
        }

        public async Task<CustomerReviewViewModel> GetMyReviews(int orderId, int CustId)
        {
            var result = await _reviewRepository.GetReviewByOrderId(orderId, CustId);
            if (result == null)
            {
                return null;
            }
            return ReviewEntityToModel(result);
        }

        public async Task<CustomerReviewViewModel> GetReviewById(int reviewId)
        {
            var result = await _reviewRepository.GetById(reviewId);
            if (result == null)
            {
                return null;
            }
            return ReviewEntityToModel(result);
        }

        public async Task<ICollection<CustomerReviewViewModel>> GetReviewsByProductId(int productId)
        {
            var result = await _reviewRepository.GetReviewsByProductId(productId);
            if (result == null || !result.Any())
            {
                return new List<CustomerReviewViewModel>();
            }
            return result.Select(r => ReviewEntityToModel(r)).ToList();
        }

        public async Task<ICollection<CustomerReviewViewModel>> GetReviewsByUserId(int userId)
        {
            var result = await _reviewRepository.GetReviewsByUserId(userId);
            if (result == null || !result.Any())
            {
                return new List<CustomerReviewViewModel>();
            }
            return result.Select(r => ReviewEntityToModel(r)).ToList();
        }

        public async Task<ICollection<CustomerReviewViewModel>> GetReviewsByYear(DateTime year)
        {
            var result = await _reviewRepository.GetReviewsByYear(year);
            if (result == null || !result.Any())
            {
                return new List<CustomerReviewViewModel>();
            }
            return result.Select(r => ReviewEntityToModel(r)).ToList();
        }

        public async Task<CustomerReviewViewModel> RejectReview(int reviewId)
        {
            var res = await _reviewRepository.GetById(reviewId);
            if (res == null)
            {
                return null;
            }
            return ReviewEntityToModel(res);
        }

        public async Task<CustomerReviewViewModel> UpdateReview(CustomerReviewRequestModel model, int reviewId)
        {
            CustomerReview newRevew = new CustomerReview
            {
                Id = reviewId,
                CustomerName = model.CustomerName,
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                ProductName = model.ProductName,
                Comment = model.Comment,
                ReviewDate = DateTime.UtcNow,
                OrderDate = DateTime.Now,
                RatingValue = model.RatingValue
            };
            var res = await _reviewRepository.Update(newRevew);
            if (res == null)
            {
                return null;
            }
            return ReviewEntityToModel(res);
        }

        public CustomerReviewViewModel ReviewEntityToModel(CustomerReview review)
        {
            return new CustomerReviewViewModel
            {
                Id = review.Id,
                CustomerName = review.CustomerName,
                OrderId = review.OrderId,
                ProductId = review.ProductId,
                ProductName = review.ProductName,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate,
                OrderDate = review.OrderDate,
                Rating = review.RatingValue,

            };
        }

    }
}
