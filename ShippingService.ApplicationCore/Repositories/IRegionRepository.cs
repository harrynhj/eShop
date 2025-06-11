using ShippingService.ApplicationCore.Entities;

namespace ShippingService.ApplicationCore.Repositories
{
    public interface IRegionRepository : IBaseRepository<Region>
    {
        public Task<Region> GetShipperIdByRegionId(int regionId);
    }

}
