using OrderService.ApplicationCore.Entities;
using OrderService.ApplicationCore.Models;
using OrderService.ApplicationCore.Repositories;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories
{
    internal class ShoppingCartItemRepository : BaseRepository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }

    }
}
