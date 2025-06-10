using Microsoft.AspNetCore.Mvc;
using ProductService.ApplicationCore.Models;
using ProductService.ApplicationCore.Services;

namespace ProductService.API.Controllers
{
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductVariationController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("api/ProductVariation/Save")]
        public async Task<IActionResult> SaveProductVariation(ProductVariationModel model)
        {
            var result = await _productService.SaveProductVariation(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save product variation");
        }

        [HttpGet("api/ProductVariation/GetProductVariation")]
        public async Task<IActionResult> GetProductVariation()
        {
            var variations = await _productService.GetProductVariation();
            return Ok(variations);
        }
    }
}
