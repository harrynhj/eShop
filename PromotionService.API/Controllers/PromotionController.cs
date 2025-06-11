using Microsoft.AspNetCore.Mvc;
using PromotionService.ApplicationCore.Models;
using PromotionService.ApplicationCore.Services;

namespace PromotionService.API.Controllers
{
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;


        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet("api/Promotion")]
        public async Task<IActionResult> GetAllPromotions()
        {
            var promotions = await _promotionService.GetAllPromotions();
            if (promotions != null && promotions.Count > 0)
            {
                return Ok(promotions);
            }
            return NotFound("No promotions found.");
        }

        [HttpPost("api/Promotion")]
        public async Task<IActionResult> CreatePromotion(PromotionRequestModel model)
        {
            var res = await _promotionService.NewPromotion(model);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("Failed to create promotion.");
        }

        [HttpPut("api/Promotion")]
        public async Task<IActionResult> UpdatePromotion(PromotionRequestModel model, int id)
        {
            var res = await _promotionService.UpdatePromotion(model, id);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("Failed to update promotion.");
        }

        [HttpGet("api/Promotion/{id}")]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            var promotion = await _promotionService.GetPromotionById(id);
            if (promotion != null)
            {
                return Ok(promotion);
            }
            return NotFound($"Promotion with ID {id} not found.");
        }

        [HttpDelete("api/Promotion/delete-{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var res = await _promotionService.DeletePromotionById(id);
            if (res != null)
            {
                return Ok($"Promotion with ID {id} deleted successfully.");
            }
            return NotFound($"Promotion with ID {id} not found.");
        }

        [HttpGet("api/Promotion/promotionByProductName")]
        public async Task<IActionResult> GetPromotionByProduct(string name)
        {
            var promotion = await _promotionService.GetPromotionByProduct(name);
            if (promotion != null)
            {
                return Ok(promotion);
            }
            return NotFound($"No promotion found for product {name}.");
        }

        [HttpGet("api/Promotion/activePromotions")]
        public async Task<IActionResult> GetActivePromotions()
        {
            var promotions = await _promotionService.GetActivePromotions();
            if (promotions != null && promotions.Count > 0)
            {
                return Ok(promotions);
            }
            return NotFound("No active promotions found.");

        }
    }
}
