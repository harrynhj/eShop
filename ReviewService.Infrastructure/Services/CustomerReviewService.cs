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

        public Task<int> CreateReview(CustomerReviewRequestModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerReviewViewModel>> GetAllReviews()
        {
            var reviews = await _reviewRepository.GetAll();

            var result = reviews.Select(review => new CustomerReviewViewModel
            {
                Id = review.Id,
                OrderId = review.OrderId,
                OrderDate = review.OrderDate,
                CustomerName = review.CustomerName,
                ProductId = review.ProductId,
                ProductName = review.ProductName,
                Rating = review.RatingValue,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            }).ToList();


            return result;
        }

        public Task<int> UpdateReview(CustomerReviewRequestModel model)
        {
            //var result = _reviewRepository.Update(new CustomerReview
            //{
            //    CustomerId = model.CustomerId,
            //    CustomerName = model.CustomerName,
            //    OrderId = model.OrderId,
            //    ProductId = model.ProductId,
            //    ProductName = model.ProductName,
            //    RatingValue = model.RatingValue,
            //    Comment = model.Comment,
            //    ReviewDate = model.ReviewDate
            //});

            throw new NotImplementedException();
        }
    }
}
