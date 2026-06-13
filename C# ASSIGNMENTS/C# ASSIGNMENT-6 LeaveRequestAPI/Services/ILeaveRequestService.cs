using LeaveRequestAPI.DTOs;

namespace LeaveRequestAPI.Services;

public interface ILeaveRequestService
{
    LeaveRequestResponseDto Create(LeaveRequestCreateDto dto);
    IEnumerable<LeaveRequestResponseDto> GetAll();
    LeaveRequestResponseDto? GetById(int id);
}
