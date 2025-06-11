using PromotionService.ApplicationCore.Entities;
using PromotionService.ApplicationCore.Models;

namespace PromotionService.ApplicationCore.Services
{
    public interface IPromotionService
    {
        public Task<PromotionRequestModel> GetPromotionById(int id);
        public Task<PromotionRequestModel> DeletePromotionById(int id);
        public Task<ICollection<PromotionRequestModel>> GetAllPromotions();
        public Task<PromotionRequestModel> GetPromotionByProduct(string name);
        public Task<ICollection<PromotionRequestModel>> GetActivePromotions();
        public PromotionRequestModel PromotionEntityToModel(PromotionSale promotionSale);
        public Task<PromotionRequestModel> NewPromotion(PromotionRequestModel model);
        public Task<PromotionRequestModel> UpdatePromotion(PromotionRequestModel model, int id);
    }
}
