using Microsoft.EntityFrameworkCore;
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
    public class ShipperRepository : BaseRepository<Shipper>, IShipperRepository
    {
        public ShipperRepository(ShippingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
