using System.ComponentModel.DataAnnotations;

namespace FleetMaintenanceApi.DTOs
{
    public class DriverCreateDto
    {
        [Required(ErrorMessage = "Driver name is required.")]
        [MaxLength(100)]
        public string DriverName { get; set; } = string.Empty;

        [Required(ErrorMessage = "License number is required.")]
        [MaxLength(50)]
        public string LicenseNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        public bool IsAvailable { get; set; }
    }
}
