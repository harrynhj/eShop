using ShippingService.ApplicationCore.Entities;
using ShippingService.ApplicationCore.Models;
using ShippingService.ApplicationCore.Repositories;
using ShippingService.ApplicationCore.Services;
using ShippingService.Infrastructure.Repositories;

namespace ShippingService.Infrastructure.Services
{
    public class ShippingServices : IShippingService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IShipperRegionRepository _shipperRegionRepository;
        private readonly IShipperRepository _shipperRepository;
        private readonly IShippingDetailsRepository _shippingDetailsRepository;


        public ShippingServices(
            IRegionRepository regionRepository,
            IShipperRegionRepository shipperRegionRepository,
            IShipperRepository shipperRepository,
            IShippingDetailsRepository shippingDetailsRepository)
        {
            _regionRepository = regionRepository;
            _shipperRegionRepository = shipperRegionRepository;
            _shipperRepository = shipperRepository;
            _shippingDetailsRepository = shippingDetailsRepository;
        }

        public async Task<ShipperRequestModel> DeleteShipperById(int id)
        {
            var res =  await _shipperRepository.DeleteById(id);
            return res != null ? ShipperToModel(res) : null;

        }

        public async Task<ShipperRequestModel> GetShipperById(int id)
        {
            var shipper = await _shipperRepository.GetById(id);
            return shipper != null ? ShipperToModel(shipper) : null;
        }

        public async Task<ShippingDetailViewModel> GetShipperByOrderId(int orderId)
        {
            var shippingDetail = await _shippingDetailsRepository.GetShipperByOrderId(orderId);
            if (shippingDetail == null) return null;
            return new ShippingDetailViewModel
            {
                Id = shippingDetail.Id,
                OrderId = shippingDetail.OrderId,
                ShippingStatus = shippingDetail.ShippingStatus,
                TrackingNumber = shippingDetail.TrackingNumber,
                ShipperName = shippingDetail.Shipper.Name,
                Contact_Person = shippingDetail.Shipper.ContactPerson,  
                Phone = shippingDetail.Shipper.Phone
            };
        }

        public async Task<ICollection<int>> GetShippersByRegionId(int regionId)
        {
            var region = await _regionRepository.GetShipperIdByRegionId(regionId);
            var res = new List<int>();
            foreach (var shipper in region.ShipperRegions)
            {
                res.Add(shipper.ShipperId);
            }
            return res;
        }

        public async Task<ShipperRequestModel> NewShipper(ShipperRequestModel model)
        {
            Shipper newShipper = new Shipper
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                ContactPerson = model.ContactPerson
            };

            var createdShipper = await _shipperRepository.Insert(newShipper);
            return createdShipper != null ? ShipperToModel(createdShipper) : null;
        }

        public async Task<ShipperRequestModel> UpdateShipper(ShipperRequestModel model, int id)
        {
            Shipper newShipper = new Shipper
            {
                Id = id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                ContactPerson = model.ContactPerson
            };

            var createdShipper = await _shipperRepository.Update(newShipper);
            return createdShipper != null ? ShipperToModel(createdShipper) : null;
        }

        public ShipperRequestModel ShipperToModel(Shipper entity)
        {
            return new ShipperRequestModel
            {
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                ContactPerson = entity.ContactPerson
            };
        }
    }
}
