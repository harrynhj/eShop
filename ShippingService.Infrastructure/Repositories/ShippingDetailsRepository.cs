using Microsoft.EntityFrameworkCore;
using ShippingService.ApplicationCore.Entities;
using ShippingService.ApplicationCore.Repositories;
using ShippingService.Infrastructure.Data;

namespace ShippingService.Infrastructure.Repositories
{
    public class ShippingDetailsRepository : BaseRepository<ShippingDetail>, IShippingDetailsRepository
    {
        public ShippingDetailsRepository(ShippingDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<ShippingDetail> GetShipperByOrderId(int orderId)
        {
            return await _DbContext
                .ShippingDetails
                .Include(sd => sd.Shipper)
                .Where(sd => sd.OrderId == orderId)
                .FirstOrDefaultAsync();
        }

    }
}
