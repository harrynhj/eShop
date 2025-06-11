using PromotionService.ApplicationCore.Entities;

namespace PromotionService.ApplicationCore.Repositories
{
    public interface IPromotionSaleRepository : IBaseRepository<PromotionSale>
    {
        public Task<ICollection<PromotionSale>> GetAllActivePromotionsAsync();
    }
}
