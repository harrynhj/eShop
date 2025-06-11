

using Microsoft.EntityFrameworkCore;
using PromotionService.ApplicationCore.Entities;
using PromotionService.ApplicationCore.Repositories;
using PromotionService.Infrastructure.Data;

namespace PromotionService.Infrastructure.Repositories
{
    public class PromotionDetailRepository : BaseRepository<PromotionDetails>, IPromotionDetailRepository
    {
        public PromotionDetailRepository(PromotionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PromotionSale> GetPromotionsByProduct(string name)
        {
            return await _DbContext.promotionDetails
                .Where(pd => pd.ProductCategoryName.Contains(name))
                .Select(pd => pd.PromotionSale)
                .FirstOrDefaultAsync();
        }
    }
}
