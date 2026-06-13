using System.ComponentModel.DataAnnotations;

namespace FleetMaintenanceApi.DTOs
{
    public class VehicleCreateDto
    {
        [Required(ErrorMessage = "Vehicle number is required.")]
        [MaxLength(20)]
        public string VehicleNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vehicle type is required.")]
        [MaxLength(50)]
        public string VehicleType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required.")]
        [MaxLength(50)]
        public string Brand { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Model { get; set; } = string.Empty;

        [Range(2001, 2100, ErrorMessage = "Purchase year must be greater than 2000.")]
        public int PurchaseYear { get; set; }

        public bool IsActive { get; set; }
    }
}
