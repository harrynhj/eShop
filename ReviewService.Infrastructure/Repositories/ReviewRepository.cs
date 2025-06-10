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


    }
}
