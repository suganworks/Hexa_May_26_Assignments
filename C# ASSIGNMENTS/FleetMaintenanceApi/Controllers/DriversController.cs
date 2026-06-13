using Microsoft.AspNetCore.Mvc;
using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Services.Interfaces;

namespace FleetMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(new { statusCode = 200, message = "Drivers retrieved successfully", data = drivers });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            if (id <= 0)
                return BadRequest(new { statusCode = 400, message = "Driver ID must be greater than zero." });

            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null)
                return NotFound(new { statusCode = 404, message = $"Driver with ID {id} not found." });

            return Ok(new { statusCode = 200, message = "Driver retrieved successfully", data = driver });
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] DriverCreateDto driverCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, data) = await _driverService.AddDriverAsync(driverCreateDto);

            if (!success)
                return BadRequest(new { statusCode = 400, message });

            return CreatedAtAction(nameof(GetDriverById), new { id = data!.DriverId },
                new { statusCode = 201, message, data });
        }
    }
}
