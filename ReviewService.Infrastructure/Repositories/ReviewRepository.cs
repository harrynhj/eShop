using Microsoft.EntityFrameworkCore;
using ReviewService.ApplicationCore.Entities;
using ReviewService.ApplicationCore.Repositories;
using ReviewService.Infrastructure.Data;

namespace ReviewService.Infrastructure.Repositories
{
    public class ReviewRepository : BaseRepository<CustomerReview>, IReviewRepository
    {
        public ReviewRepository(ReviewDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<CustomerReview> GetReviewByOrderId(int orderId, int custId)
        {
            return await _DbContext.CustomerReviews
                .Where(r => r.OrderId == orderId && r.CustomerId == custId)
                .FirstOrDefaultAsync(r => r.OrderId == orderId);
        }

        public async Task<ICollection<CustomerReview>> GetReviewsByProductId(int productId)
        {
            return await _DbContext.CustomerReviews
                .Where(r => r.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ICollection<CustomerReview>> GetReviewsByUserId(int userId)
        {
            return await _DbContext.CustomerReviews
                .Where(r => r.CustomerId == userId)
                .ToListAsync();
        }

        public async Task<ICollection<CustomerReview>> GetReviewsByYear(DateTime year) { 
            return await _DbContext.CustomerReviews
                .Where(r => r.ReviewDate.Year == year.Year)
                .ToListAsync();
        }


    }
}
