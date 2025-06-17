using Microsoft.AspNetCore.Mvc;
using OrderService.ApplicationCore.Services;
using OrderService.Infrastructure.Services;
using OrderService.ApplicationCore.Models;

namespace OrderService.API.Controllers
{
    public class ShoppingCartController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public ShoppingCartController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("api/ShoppingCart/GetShoppingCartByCustomerId")]
        public async Task<IActionResult> GetShoppingCartByCustomerId(int customerId)
        {
            var cart = await _orderService.GetCartByCustId(customerId);
            if (cart != null)
            {
                return Ok(cart);
            }
            return NotFound($"Shopping cart for customer ID {customerId} not found.");
        }

        [HttpPost("api/ShoppingCart/SaveShoppingCart")]
        public async Task<IActionResult> SaveShoppingCart(ShoppingCartItemModel model)
        {
            var result = await _orderService.SaveCart(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save shopping cart");
        }

        [HttpDelete("api/ShoppingCart/DeleteShoppingCart")]
        public async Task<IActionResult> DeleteShoppingCart(int customerId)
        {
            var result = await _orderService.DeleteCart(customerId);
            if (result)
            {
                return Ok($"Shopping cart for customer ID {customerId} deleted successfully.");
            }
            return NotFound($"Shopping cart for customer ID {customerId} not found.");
        }


    }
}
