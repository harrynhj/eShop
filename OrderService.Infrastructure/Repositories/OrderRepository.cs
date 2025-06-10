using Microsoft.EntityFrameworkCore;
using OrderService.ApplicationCore.Entities;
using OrderService.ApplicationCore.Repositories;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Order>> GetAllOrders(int page)
        {
            return await _DbContext
                .Orders
                .OrderBy(o => o.OrderDate)
                .Skip((page - 1) * 10).Take(10).ToListAsync();
        }

        public async Task<ICollection<PaymentMethod>> GetCustPayments(int CustId)
        {
            return await _DbContext.Orders
                .Where(o => o.CustomerId == CustId)
                .Select(o => o.PaymentMethod)
                .Distinct()
                .ToListAsync();
        }

        public async Task<ICollection<Order>> GetUserOrderHistory(int Custid)
        {
            return await _DbContext.Orders.Where(o => o.CustomerId == Custid).ToListAsync(); 
        }

    }
    
    
}
