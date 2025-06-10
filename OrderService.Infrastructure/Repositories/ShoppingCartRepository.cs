using Microsoft.EntityFrameworkCore;
using OrderService.ApplicationCore.Entities;
using OrderService.ApplicationCore.Repositories;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> DeleteCart(int custId)
        {
            var carts = await _DbContext.ShoppingCarts
                .Include(c => c.ShoppingCartItems)
                .Where(c => c.CustomerId == custId)
                .ToListAsync();

            if (!carts.Any())
                return false;

            foreach (var cart in carts)
            {
                _DbContext.ShoppingCartItems.RemoveRange(cart.ShoppingCartItems);
                _DbContext.ShoppingCarts.Remove(cart);
            }

            await _DbContext.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<ShoppingCartItem>> GetShoppingCartItemsByCustId(int CustId)
        {
            return await _DbContext.ShoppingCarts.Include(c => c.ShoppingCartItems)
                .Where(c => c.CustomerId == CustId)
                .SelectMany(c => c.ShoppingCartItems)
                .ToListAsync();
        }
    }
    
    
}
