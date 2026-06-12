using Microsoft.AspNetCore.Mvc;
using LeaveRequestAPI.DTOs;
using LeaveRequestAPI.Services;

namespace LeaveRequestAPI.Controllers;

[ApiController]
[Route("api/leaverequests")]
public class LeaveRequestsController : ControllerBase
{
    private readonly ILeaveRequestService _service;

    public LeaveRequestsController(ILeaveRequestService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create([FromBody] LeaveRequestCreateDto dto)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var result = _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.LeaveRequestId }, result);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var result = _service.GetById(id);
        return result is null ? NotFound() : Ok(result);
    }
}
