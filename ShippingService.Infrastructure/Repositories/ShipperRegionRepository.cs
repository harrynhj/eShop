using ShippingService.ApplicationCore.Entities;
using ShippingService.ApplicationCore.Repositories;
using ShippingService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingService.Infrastructure.Repositories
{
    public class ShipperRegionRepository : BaseRepository<ShipperRegion>, IShipperRegionRepository
    {
        public ShipperRegionRepository(ShippingDbContext dbContext) : base(dbContext)
        {

        }
    }
}
