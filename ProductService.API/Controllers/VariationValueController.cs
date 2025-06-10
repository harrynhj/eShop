using Microsoft.AspNetCore.Mvc;
using ProductService.ApplicationCore.Models;
using ProductService.ApplicationCore.Services;

namespace ProductService.API.Controllers
{
    public class VariationValueController : ControllerBase
    {
        private readonly IProductService _productService;
        public VariationValueController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("api/VariationVlue/Save")]
        public async Task<IActionResult> SaveVariationValue(VariationValueModel model)
        {
            var result = await _productService.SaveVariationValue(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save variation value");
        }

        [HttpGet("api/VariationValue/GetVariationId")]
        public async Task<IActionResult> GetVariationValues()
        {
            var variationValues = await _productService.GetVariationValues();
            if (variationValues != null)
            {
                return Ok(variationValues);
            }
            return NotFound("No variation values found.");
        }
    }
}
