using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.ApplicationCore.Models;
using ProductService.ApplicationCore.Services;

namespace ProductService.API.Controllers
{
    public class CategoryVariationController : ControllerBase
    {
        private readonly IProductService _productService;
        public CategoryVariationController(IProductService Productservices)
        {
            _productService = Productservices;
        }

        [Authorize]
        [HttpPost("CategoryVariation/Save")]
        public async Task<IActionResult> SaveCategoryVariation(CategoryVariationRequestModel model)
        {
            var result = await _productService.SaveCategoryVariance(model);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save category variation");
        }

        [HttpGet("CategoryVariation/GetAll")]
        public async Task<IActionResult> GetAllCategoryVariations()
        {
            var categoryVariations = await _productService.GetAllCategoryVariance();
            return Ok(categoryVariations);
        }

        [HttpGet("CategoryVariation/GetCategoryVariationById")]
        public async Task<IActionResult> GetCategoryVariationById(int id)
        {
            var categoryVariation = await _productService.GetCategoryVarianceById(id);
            if (categoryVariation != null)
            {
                return Ok(categoryVariation);
            }
            return NotFound($"Category variation with ID {id} not found.");
        }

        [HttpGet("CategoryVariation/GetCategoryVariationByCategoryId")]
        public async Task<IActionResult> GetCategoryVariationByCategoryId(int id)
        {
            var categoryVariations = await _productService.GetAllCategoryVarianceByCategoryId(id);
            if (categoryVariations != null && categoryVariations.Count > 0)
            {
                return Ok(categoryVariations);
            }
            return NotFound($"No category variations found for category ID {id}.");
        }

        [Authorize]
        [HttpDelete("CategoryVariation/Delete")]
        public async Task<IActionResult> DeleteCategoryVariation(int id)
        {
            var result = await _productService.DeleteCategoryVariance(id);
            if (result)
            {
                return Ok($"Category variation with ID {id} deleted successfully.");
            }
            return NotFound($"Category variation with ID {id} not found.");
        }
    }
}
