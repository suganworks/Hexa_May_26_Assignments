using LeaveRequestAPI.DTOs;
using LeaveRequestAPI.Models;

namespace LeaveRequestAPI.Services;

public class LeaveRequestService : ILeaveRequestService
{
    private static readonly List<LeaveRequest> _store = new();
    private static int _nextId = 1;

    public LeaveRequestResponseDto Create(LeaveRequestCreateDto dto)
    {
        var entity = new LeaveRequest
        {
            LeaveRequestId = _nextId++,
            EmployeeName   = dto.EmployeeName,
            EmployeeEmail  = dto.EmployeeEmail,
            MobileNumber   = dto.MobileNumber,
            LeaveType      = dto.LeaveType,
            StartDate      = dto.StartDate,
            EndDate        = dto.EndDate,
            Reason         = dto.Reason,
            TotalDays      = (dto.EndDate.Date - dto.StartDate.Date).Days + 1,
            Status         = "Pending",
            CreatedOn      = DateTime.UtcNow
        };
        _store.Add(entity);
        return MapToDto(entity);
    }

    public IEnumerable<LeaveRequestResponseDto> GetAll() => _store.Select(MapToDto);

    public LeaveRequestResponseDto? GetById(int id)
    {
        var entity = _store.FirstOrDefault(r => r.LeaveRequestId == id);
        return entity is null ? null : MapToDto(entity);
    }

    private static LeaveRequestResponseDto MapToDto(LeaveRequest r) => new()
    {
        LeaveRequestId = r.LeaveRequestId,
        EmployeeName   = r.EmployeeName,
        EmployeeEmail  = r.EmployeeEmail,
        LeaveType      = r.LeaveType,
        StartDate      = r.StartDate,
        EndDate        = r.EndDate,
        Reason         = r.Reason,
        TotalDays      = r.TotalDays,
        Status         = r.Status,
        CreatedOn      = r.CreatedOn
    };
}
