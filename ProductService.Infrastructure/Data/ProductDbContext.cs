using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.ApplicationCore.Entities;

namespace ProductService.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public DbSet<CategoryVariation> CategoryVariations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductVariationValues> ProductVariationValues { get; set; }
        public DbSet<VariationValue> VariationValues { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(o => o.Property(p => p.Price).HasColumnType("decimal(18,2)"));

            modelBuilder.Entity<ProductVariationValues>(entity =>
            {
                entity.HasKey(pv => new { pv.ProductId, pv.VariationValueId });
            });

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

    }
}
