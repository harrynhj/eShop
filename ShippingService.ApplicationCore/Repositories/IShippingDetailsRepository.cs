using ShippingService.ApplicationCore.Entities;

namespace ShippingService.ApplicationCore.Repositories
{
    public interface IShippingDetailsRepository : IBaseRepository<ShippingDetail>
    {
        public Task<ShippingDetail> GetShipperByOrderId(int orderId);
    }
}
