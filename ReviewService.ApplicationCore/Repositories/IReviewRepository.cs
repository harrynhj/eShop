using ReviewService.ApplicationCore.Entities;

namespace ReviewService.ApplicationCore.Repositories
{
    public interface IReviewRepository : IBaseRepository<CustomerReview>
    {
        public Task<CustomerReview> GetReviewByOrderId(int orderId, int custId);
        public Task<ICollection<CustomerReview>> GetReviewsByProductId(int productId);
        public Task<ICollection<CustomerReview>> GetReviewsByUserId(int userId);
        public Task<ICollection<CustomerReview>> GetReviewsByYear(DateTime year);
        
    }
}
