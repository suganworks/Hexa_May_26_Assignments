using System.ComponentModel.DataAnnotations;

namespace LeaveRequestAPI.Attributes;

public class ValidLeaveTypeAttribute : ValidationAttribute
{
    private static readonly string[] AllowedTypes = { "Sick", "Casual", "Earned" };

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is string leaveType && AllowedTypes.Contains(leaveType))
            return ValidationResult.Success;

        return new ValidationResult("LeaveType must be Sick, Casual, or Earned.");
    }
}
