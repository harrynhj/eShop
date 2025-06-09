using Microsoft.EntityFrameworkCore;
using ReviewService.ApplicationCore.Entities;


namespace ReviewService.Infrastructure.Data
{
    public class ReviewDbContext : DbContext
    {
        public DbSet<CustomerReview> CustomerReviews { get; set; }

        public ReviewDbContext(DbContextOptions<ReviewDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configurations can be added here if needed
        }


    }
}
