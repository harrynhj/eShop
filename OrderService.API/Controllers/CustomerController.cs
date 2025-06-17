using Microsoft.AspNetCore.Mvc;
using OrderService.ApplicationCore.Services;
using OrderService.Infrastructure.Services;
using OrderService.ApplicationCore.Models;

namespace OrderService.API.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public CustomerController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("api/Customer/GetCustomerAddressByUserId")]
        public async Task<IActionResult> GetCustomerAddressByUserId(int userId)
        {
            var result = await _orderService.GetCustomerAddressById(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"No address found for user ID {userId}.");
        }

        [HttpPost("api/Customer/SaveCustomerAddress")]
        public async Task<IActionResult> SaveCustomerAddress(CustomerModel model, int CustomerId)
        {
            if (model == null)
            {
                return BadRequest("Invalid address data.");
            }
            var result = await _orderService.SaveCustomerAddress(model, CustomerId);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save customer address.");
        }

    }
}
