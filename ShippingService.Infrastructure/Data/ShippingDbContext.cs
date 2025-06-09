using Microsoft.EntityFrameworkCore;
using ShippingService.ApplicationCore.Entities;

namespace ShippingService.Infrastructure.Data
{
    public class ShippingDbContext : DbContext
    {

        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<ShipperRegion> ShipperRegions { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }

        public ShippingDbContext(DbContextOptions<ShippingDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ShipperRegion>(entity =>
            {
                entity.HasKey(pv => new { pv.RegionId, pv.ShipperId });
            });


        }

    }
}
