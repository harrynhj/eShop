using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.ApplicationCore.Models;
using ProductService.ApplicationCore.Services;

namespace ProductService.API.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService Productservices)
        {
            _productService = Productservices;
        }

        [HttpGet("Product/GetListProducts")]
        public async Task<IActionResult> GetListProducts(int page = 1, int category = -1)
        {
            var products = await _productService.GetListProducts(page, category);
            return Ok(products);
        }

        [HttpGet("Product/GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound($"Product with ID {id} not found.");
        }

        [Authorize]
        [HttpPost("Product/Save")]
        public async Task<IActionResult> SaveProduct(ProductModel model)
        {
            var result = await _productService.SaveProduct(model);
            if (result > 0)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save product");
        }

        [Authorize]
        [HttpPut("Product/Update")]
        public async Task<IActionResult> UpdateProduct(ProductModel model)
        {
            var result = await _productService.UpdateProduct(model);
            if (result)
            {
                return Ok("Product updated successfully.");
            }
            return BadRequest("Failed to update product");
        }

        [Authorize]
        [HttpPut("Product/InActive")]
        public async Task<IActionResult> InactiveProduct(int id)
        {
            var result = await _productService.InactiveProduct(id);
            if (result)
            {
                return Ok($"Product with ID {id} has been deactivated.");
            }
            return NotFound($"Product with ID {id} not found.");
        }

        [HttpGet("Product/GetProductByCategoryId")]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryId(categoryId);
            return Ok(products);
        }

        [HttpGet("Product/GetProductByName")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var products = await _productService.GetProductsByName(name);
            return Ok(products);
        }

        [Authorize]
        [HttpDelete("Product/DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result)
            {
                return Ok($"Product with ID {id} deleted successfully.");
            }
            return NotFound($"Product with ID {id} not found.");
        }

    }
}
