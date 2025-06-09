using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.ApplicationCore.Entities;

namespace OrderService.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetails>(o => o.Property(p => p.Price).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<OrderDetails>(o => o.Property(d => d.Discount).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<Order>(o => o.Property(b => b.BillAmount).HasColumnType("decimal(18,2)"));
            modelBuilder.Entity<ShoppingCartItem>(o => o.Property(p => p.Price).HasColumnType("decimal(18,2)"));

        }

    }
}
