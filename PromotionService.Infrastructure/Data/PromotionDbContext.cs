using Microsoft.EntityFrameworkCore;
using PromotionService.ApplicationCore.Entities;

namespace PromotionService.Infrastructure.Data
{
    public class PromotionDbContext : DbContext
    {
        public DbSet<PromotionSale> promotionSales { get; set; }
        public DbSet<PromotionDetails> promotionDetails { get; set; }

        public PromotionDbContext(DbContextOptions<PromotionDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PromotionSale>(o => o.Property(p => p.Discount).HasColumnType("decimal(3,2)"));

        }
    }
}
