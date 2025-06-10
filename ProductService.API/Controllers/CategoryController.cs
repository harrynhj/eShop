using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.ApplicationCore.Models;
using ProductService.ApplicationCore.Services;
using ProductService.Infrastructure.Services;
using System.ComponentModel;

namespace ProductService.API.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly IProductService _ProductServices;

        public CategoryController(IProductService productServices)
        {
            _ProductServices = productServices;
            
        }
        [Authorize]
        [HttpPost("Category/SaveCategory")]
        public async Task<IActionResult> SaveCategory(CategoryRequestModel model) { 
            var result = await _ProductServices.SaveCategory(model);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save category");
        }

        [HttpGet("Category/GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var categories = await _ProductServices.GetAllCategory();
            return Ok(categories);
        }

        [HttpGet("Category/GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _ProductServices.GetCategoryById(id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound($"Category with ID {id} not found.");
        }

        [Authorize]
        [HttpDelete("Category/Delete")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _ProductServices.DeleteCategory(id);
            if (result)
            {
                return Ok($"Category with ID {id} deleted successfully.");
            }
            return NotFound($"Category with ID {id} not found.");
        }

        [HttpGet("Category/GetCategoryByParentCategoryId")]
        public async Task<IActionResult> GetCategoryByParentCategoryId(int id)
        {
            var categories = await _ProductServices.GetCategoryByParentCategoryId(id);
            if (categories != null && categories.Any())
            {
                return Ok(categories);
            }
            return NotFound($"No categories found for parent category ID {id}.");
        }

    }
}
