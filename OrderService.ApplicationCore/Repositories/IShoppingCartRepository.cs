using OrderService.ApplicationCore.Entities;

namespace OrderService.ApplicationCore.Repositories
{
    public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
    {
        public Task<bool> DeleteCart(int custId);
        public Task<ICollection<ShoppingCartItem>> GetShoppingCartItemsByCustId(int CustId);
    }
}
