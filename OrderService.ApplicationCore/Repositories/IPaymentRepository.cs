using OrderService.ApplicationCore.Entities;

namespace OrderService.ApplicationCore.Repositories
{
    public interface IPaymentRepository : IBaseRepository<PaymentMethod>
    {
    }
}
