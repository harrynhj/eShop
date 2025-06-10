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
        public Task<List<CustomerReviewViewModel>> GetAllReviews();
        public Task<int> CreateReview(CustomerReviewRequestModel model);
        public Task<int> UpdateReview(CustomerReviewRequestModel model);



    }
}
