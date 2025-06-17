using Microsoft.AspNetCore.Mvc;
using OrderService.ApplicationCore.Services;
using OrderService.Infrastructure.Services;
using OrderService.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace OrderService.API.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpGet("api/Order/GetAllOrders")]
        public async Task<IActionResult> GetAllOrders(int page = 1)
        {
            var orders = await _orderService.GetAllOrders(page);
            return Ok(orders);
        }

        [HttpPost("api/Order/SaveOrder")]
        public async Task<IActionResult> SaveOrder(OrderRequestModel model)
        {
            var result = await _orderService.SaveOrder(model);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save order");
        }


        [HttpGet("api/Order/CheckOrderHistory")]
        public async Task<IActionResult> CheckOrderHistory(int userId)
        {
            var orderHistory = await _orderService.CheckOrderHistory(userId);
            if (orderHistory != null)
            {
                return Ok(orderHistory);
            }
            return NotFound($"No order history found for user ID {userId}.");
        }

        [HttpGet("api/Order/CheckOrderStatus")]
        public async Task<IActionResult> CheckOrderStatus(int orderId)
        {
            var orderStatus = await _orderService.CheckOrderStatus(orderId);
            if (orderStatus != null)
            {
                return Ok(orderStatus);
            }
            return NotFound($"No order found with ID {orderId}.");
        }

        [HttpPut("api/Order/CancelOrder")]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            var result = await _orderService.CancelOrder(orderId);
            if (result != null)
            {
                return Ok($"Order with ID {orderId} cancelled successfully.");
            }
            return NotFound($"Order with ID {orderId} not found or cannot be cancelled.");
        }

        [HttpPost("api/Order/OrderCompleted")]
        public async Task<IActionResult> OrderCompleted(OrderRequestModel model)
        {
            var result = await _orderService.AddCompletedOrder(model);
            if (result != null)
            {
                return Ok($"success");
            }
            return NotFound($"order not found");

        }

        [HttpPut("api/Order/UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderRequestModel model, int OrderId)
        {
            var result = await _orderService.UpdateOrder(model, OrderId);
            if (result != null)
            {
                return Ok($"Order with ID {OrderId} updated successfully.");
            }
            return NotFound($"Order with ID {OrderId} not found.");
        }
    }
}
