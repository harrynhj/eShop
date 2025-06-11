using ShippingService.ApplicationCore.Entities;
using ShippingService.ApplicationCore.Models;
using System.Runtime.CompilerServices;

namespace ShippingService.ApplicationCore.Services
{
    public interface IShippingService
    {
        public Task<ShippingDetailViewModel> GetShipperByOrderId(int orderId);
        public Task<ShipperRequestModel> NewShipper(ShipperRequestModel model);
        public Task<ShipperRequestModel> UpdateShipper(ShipperRequestModel model, int id);
        public Task<ShipperRequestModel> GetShipperById(int id);
        public Task<ShipperRequestModel> DeleteShipperById(int id);
        public Task<ICollection<int>> GetShippersByRegionId(int regionId);
        public ShipperRequestModel ShipperToModel(Shipper entity);

    }
}
