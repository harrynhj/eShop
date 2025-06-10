using Microsoft.AspNetCore.Mvc;
using OrderService.ApplicationCore.Services;
using OrderService.Infrastructure.Services;
using OrderService.ApplicationCore.Models;

namespace OrderService.API.Controllers
{
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public ShoppingCartItemController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpDelete("api/ShoppingCartItem/DeleteShoppingCartItemById")]
        public async Task<IActionResult> DeleteShoppingCartItemById(int id)
        {
            var result = await _orderService.DeleteCartItem(id);
            if (result!= null)
            {
                return Ok(result);
            }
            return NotFound($"Shopping cart item with ID {id} not found.");
        }
    }
}
