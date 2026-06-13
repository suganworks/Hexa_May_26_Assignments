using System.ComponentModel.DataAnnotations;
using LeaveRequestAPI.Attributes;

namespace LeaveRequestAPI.DTOs;

public class LeaveRequestCreateDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string EmployeeName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string EmployeeEmail { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "MobileNumber must be a valid 10-digit Indian mobile number.")]
    public string MobileNumber { get; set; } = string.Empty;

    [Required]
    [ValidLeaveType]
    public string LeaveType { get; set; } = string.Empty;

    [Required]
    [CustomValidation(typeof(LeaveRequestCreateDto), nameof(ValidateFutureDate))]
    public DateTime StartDate { get; set; }

    [Required]
    [CustomValidation(typeof(LeaveRequestCreateDto), nameof(ValidateFutureDate))]
    public DateTime EndDate { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(250)]
    public string Reason { get; set; } = string.Empty;

    public static ValidationResult? ValidateFutureDate(DateTime date, ValidationContext context)
    {
        if (date.Date > DateTime.Today)
            return ValidationResult.Success;

        return new ValidationResult($"{context.DisplayName} must be a future date.");
    }
}
