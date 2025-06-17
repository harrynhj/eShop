using Microsoft.AspNetCore.Mvc;
using OrderService.ApplicationCore.Services;
using OrderService.Infrastructure.Services;
using OrderService.ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace OrderService.API.Controllers
{
    public class PaymentController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public PaymentController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Authorize]
        [HttpGet("api/Payment/GetPaymentByCustomerId")]
        public async Task<IActionResult> GetPaymentByCustomerId(int customerId)
        {
            var payment = await _orderService.GetPaymentMethodByCustId(customerId);
            if (payment != null)
            {
                return Ok(payment);
            }
            return NotFound($"Payment for Customer ID {customerId} not found.");
        }

        [HttpPost("api/Payment/SavePayment")]
        public async Task<IActionResult> SavePayment(PaymentModel model)
        {
            if (model == null)
            {
                return BadRequest("Payment model cannot be null.");
            }
            var result = await _orderService.SavePayment(model);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save payment method.");
        }

        [HttpDelete("api/Payment/DeletePayment")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var result = await _orderService.DeletePayment(id);
            if (result!=null)
            {
                return Ok(result);
            }
            return NotFound($"Payment with ID {id} not found.");
        }

        [HttpPut("api/Payment/UpdatePayment")]
        public async Task<IActionResult> UpdatePayment(PaymentModel model)
        {
            var result = await _orderService.UpdatePayment(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to update payment method.");
        }


    }
}
