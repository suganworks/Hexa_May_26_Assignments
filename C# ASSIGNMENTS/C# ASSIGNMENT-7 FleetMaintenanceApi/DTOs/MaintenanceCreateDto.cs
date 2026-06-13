using System.ComponentModel.DataAnnotations;

namespace FleetMaintenanceApi.DTOs
{
    public class MaintenanceCreateDto
    {
        [Required(ErrorMessage = "VehicleId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "VehicleId must be a positive number.")]
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "DriverId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "DriverId must be a positive number.")]
        public int DriverId { get; set; }

        [Required(ErrorMessage = "Service date is required.")]
        public DateOnly ServiceDate { get; set; }

        [Required(ErrorMessage = "Service type is required.")]
        [MaxLength(100)]
        public string ServiceType { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Service cost must be greater than 0.")]
        public decimal ServiceCost { get; set; }

        [Required(ErrorMessage = "Service status is required.")]
        [MaxLength(30)]
        public string ServiceStatus { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Remarks { get; set; }
    }
}
