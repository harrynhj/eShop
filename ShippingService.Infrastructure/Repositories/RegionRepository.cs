using Microsoft.EntityFrameworkCore;
using ShippingService.ApplicationCore.Entities;
using ShippingService.ApplicationCore.Repositories;
using ShippingService.Infrastructure.Data;

namespace ShippingService.Infrastructure.Repositories
{
    public class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        public RegionRepository(ShippingDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Region> GetShipperIdByRegionId(int regionId)
        {
            return await _DbContext
                .Regions
                .Include(s => s.ShipperRegions)
                .Where(r => r.Id == regionId)
                .FirstOrDefaultAsync();                
                
        }
    }
}
