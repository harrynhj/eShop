using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShippingService.ApplicationCore.Models;
using ShippingService.ApplicationCore.Services;

namespace ShippingService.API.Controllers
{
    public class ShipperController : ControllerBase
    {
        private readonly IShippingService _shippingService;

        public ShipperController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        [HttpGet("api/Shipper")]
        public async Task<IActionResult> GetShippers(int OrderId)
        {
            var shippers = await _shippingService.GetShipperByOrderId(OrderId);
            if (shippers != null)
            {
                return Ok(shippers);
            }
            return NotFound("No shippers found.");
        }

        [Authorize]
        [HttpPost("api/Shipper/Shipper")]
        public async Task<IActionResult> SaveShipper(ShipperRequestModel model)
        {
            var result = await _shippingService.NewShipper(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to save shipper");
        }

        [Authorize]
        [HttpPut("api/Shipper/Shipper")]
        public async Task<IActionResult> UpdateShipper(ShipperRequestModel model, int ShipperId)
        {
            var result = await _shippingService.UpdateShipper(model, ShipperId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Failed to update shipper");
        }

        [HttpGet("api/Shipper/{id}")]
        public async Task<IActionResult> GetShipperById(int id)
        {
            var shipper = await _shippingService.GetShipperById(id);
            if (shipper != null)
            {
                return Ok(shipper);
            }
            return NotFound($"Shipper with ID {id} not found.");
        }

        [HttpDelete("api/Shipper/delete-{id}")]
        public async Task<IActionResult> DeleteShipper(int id)
        {
            var result = await _shippingService.DeleteShipperById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Shipper with ID {id} not found.");

        }

        [HttpGet("api/Shipper/region/{region}")]
        public async Task<IActionResult> GetShipperByRegion(int region)
        {
            var shippers = await _shippingService.GetShippersByRegionId(region);
            if (shippers != null && shippers.Any())
            {
                return Ok(shippers);
            }
            return NotFound($"No shippers found for region {region}.");
        }
    }
}
