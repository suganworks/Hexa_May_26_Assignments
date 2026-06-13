using Microsoft.AspNetCore.Mvc;
using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Services.Interfaces;

namespace FleetMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceRecordsController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceRecordsController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaintenanceRecords([FromQuery] MaintenanceFilterRequestDto filter)
        {
            var (success, message, data) = await _maintenanceService.GetPagedMaintenanceRecordsAsync(filter);

            if (!success)
                return BadRequest(new { statusCode = 400, message });

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddMaintenanceRecord([FromBody] MaintenanceCreateDto maintenanceCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, data) = await _maintenanceService.AddMaintenanceRecordAsync(maintenanceCreateDto);

            if (!success)
                return BadRequest(new { statusCode = 400, message });

            return CreatedAtAction(null, new { statusCode = 201, message, data });
        }
    }
}
