using PromotionService.ApplicationCore.Entities;

namespace PromotionService.ApplicationCore.Repositories
{
    public interface IPromotionDetailRepository : IBaseRepository<PromotionDetails>
    {
        public Task<PromotionSale> GetPromotionsByProduct(string name);
    }
}
