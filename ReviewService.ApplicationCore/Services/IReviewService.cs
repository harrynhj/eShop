using ReviewService.ApplicationCore.Entities;
using ReviewService.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewService.ApplicationCore.Services
{
    public interface IReviewService
    {
        public Task<CustomerReviewViewModel> GetMyReviews(int orderId, int CustId);
        public Task<CustomerReviewViewModel> CreateReview(CustomerReviewRequestModel model, int orderId);
        public Task<CustomerReviewViewModel> UpdateReview(CustomerReviewRequestModel model, int reviewId);
        public Task<CustomerReviewViewModel> DeleteReview(int reviewId);
        public Task<CustomerReviewViewModel> GetReviewById(int reviewId);
        public Task<ICollection<CustomerReviewViewModel>> GetReviewsByUserId(int userId);
        public Task<ICollection<CustomerReviewViewModel>> GetReviewsByProductId(int productId);
        public Task<ICollection<CustomerReviewViewModel>> GetReviewsByYear(DateTime year);
        public Task<CustomerReviewViewModel> ApproveReview(int reviewId);
        public Task<CustomerReviewViewModel> RejectReview(int reviewId);

        public CustomerReviewViewModel ReviewEntityToModel(CustomerReview review);




    }
}
