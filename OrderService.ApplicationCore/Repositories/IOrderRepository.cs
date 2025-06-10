using OrderService.ApplicationCore.Entities;

namespace OrderService.ApplicationCore.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Task<ICollection<Order>> GetUserOrderHistory(int Custid);
        public Task<ICollection<Order>> GetAllOrders(int page);
        public Task<ICollection<PaymentMethod>> GetCustPayments(int CustId);
    }
}
