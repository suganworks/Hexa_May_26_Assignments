using Microsoft.AspNetCore.Mvc;
using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Services.Interfaces;

namespace FleetMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return Ok(new { statusCode = 200, message = "Vehicles retrieved successfully", data = vehicles });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
        {
            if (id <= 0)
                return BadRequest(new { statusCode = 400, message = "Vehicle ID must be greater than zero." });

            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null)
                return NotFound(new { statusCode = 404, message = $"Vehicle with ID {id} not found." });

            return Ok(new { statusCode = 200, message = "Vehicle retrieved successfully", data = vehicle });
        }

        [HttpPost]
        public async Task<IActionResult> AddVehicle([FromBody] VehicleCreateDto vehicleCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, data) = await _vehicleService.AddVehicleAsync(vehicleCreateDto);

            if (!success)
                return BadRequest(new { statusCode = 400, message });

            return CreatedAtAction(nameof(GetVehicleById), new { id = data!.VehicleId },
                new { statusCode = 201, message, data });
        }
    }
}
