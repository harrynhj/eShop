
using Microsoft.EntityFrameworkCore;
using PromotionService.ApplicationCore.Entities;
using PromotionService.ApplicationCore.Repositories;
using PromotionService.Infrastructure.Data;

namespace PromotionService.Infrastructure.Repositories
{
    public class PromotionSaleRepository : BaseRepository<PromotionSale>, IPromotionSaleRepository
    {
        public PromotionSaleRepository(PromotionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<PromotionSale>> GetAllActivePromotionsAsync()
        {
            var time = DateTime.UtcNow;
            return await _DbContext.promotionSales
                .Where(p => p.StartDate <= time && p.EndDate >= time)
                .ToListAsync();

        }



    }
}
