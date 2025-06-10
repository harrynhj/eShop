using OrderService.ApplicationCore.Entities;
using OrderService.ApplicationCore.Repositories;
using OrderService.Infrastructure.Data;

namespace OrderService.Infrastructure.Repositories
{
    public class PaymentRepository : BaseRepository<PaymentMethod>, IPaymentRepository
    {
        public PaymentRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }

    }
}
