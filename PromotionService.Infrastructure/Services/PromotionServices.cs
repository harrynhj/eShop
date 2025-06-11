using PromotionService.ApplicationCore.Services;
using PromotionService.Infrastructure.Repositories;
using PromotionService.ApplicationCore.Repositories;
using PromotionService.ApplicationCore.Models;
using PromotionService.ApplicationCore.Entities;

namespace PromotionService.Infrastructure.Services
{
    public class PromotionServices : IPromotionService
    {
        private readonly IPromotionDetailRepository _promotionDetailRepository;
        private readonly IPromotionSaleRepository _promotionRepository;

        public PromotionServices(IPromotionDetailRepository promotionDetailRepository, IPromotionSaleRepository promotionRepository)
        {
            _promotionDetailRepository = promotionDetailRepository;
            _promotionRepository = promotionRepository;
        }

        public async Task<PromotionRequestModel> DeletePromotionById(int id)
        {
            var res = await _promotionRepository.DeleteById(id);
            if (res != null)
            {
                return PromotionEntityToModel(res);
            }
            return null;
        }

        public async Task<PromotionRequestModel> GetPromotionByProduct(string name)
        {
            var res = await _promotionDetailRepository.GetPromotionsByProduct(name);
            if (res != null)
            {
                return PromotionEntityToModel(res);
            }
            return null;
        }

        public async Task<ICollection<PromotionRequestModel>> GetActivePromotions()
        {
            var res = await _promotionRepository.GetAllActivePromotionsAsync();
            if (res != null && res.Count > 0)
            {
                return res.Select(PromotionEntityToModel).ToList();
            }
            return new List<PromotionRequestModel>();
        }

        public async Task<ICollection<PromotionRequestModel>> GetAllPromotions()
        {
            var res = await _promotionRepository.GetAll();
            if (res != null)
            {
                return res.Select(PromotionEntityToModel).ToList();
            }
            return new List<PromotionRequestModel>();
        }

        public async Task<PromotionRequestModel> GetPromotionById(int id)
        {
            var res = await _promotionRepository.GetById(id);
            if (res != null)
            {
                return PromotionEntityToModel(res);
            }
            return null;
        }

        public async Task<PromotionRequestModel> NewPromotion(PromotionRequestModel model) 
        { 
           PromotionSale newPromotion = new PromotionSale
            {
                Name = model.Name,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Discount = model.Discount
            };
            var res = await _promotionRepository.Insert(newPromotion);
            if (res != null)
            {
                return PromotionEntityToModel(res);
            }
            return null;
        }

        public async Task<PromotionRequestModel> UpdatePromotion(PromotionRequestModel model, int id) 
        {
            PromotionSale newPromotion = new PromotionSale
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Discount = model.Discount
            };
            var res = await _promotionRepository.Update(newPromotion);
            if (res != null)
            {
                return PromotionEntityToModel(res);
            }
            return null;
        }


        public PromotionRequestModel PromotionEntityToModel(PromotionSale promotionSale)
        {
            return new PromotionRequestModel
            {
                Id = promotionSale.Id,
                Name = promotionSale.Name,
                Description = promotionSale.Description,
                StartDate = promotionSale.StartDate,
                EndDate = promotionSale.EndDate,
                Discount = promotionSale.Discount,
            };
        }
    }
}
