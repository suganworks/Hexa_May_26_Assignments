using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Models;
using FleetMaintenanceApi.Repositories.Interfaces;
using FleetMaintenanceApi.Services.Interfaces;

namespace FleetMaintenanceApi.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<List<VehicleResponseDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
            return vehicles.Select(MapToResponseDto).ToList();
        }

        public async Task<VehicleResponseDto?> GetVehicleByIdAsync(int vehicleId)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
            return vehicle == null ? null : MapToResponseDto(vehicle);
        }

        public async Task<(bool Success, string Message, VehicleResponseDto? Data)>
            AddVehicleAsync(VehicleCreateDto vehicleCreateDto)
        {
            var vehicle = new Vehicle
            {
                VehicleNumber = vehicleCreateDto.VehicleNumber,
                VehicleType   = vehicleCreateDto.VehicleType,
                Brand         = vehicleCreateDto.Brand,
                Model         = vehicleCreateDto.Model,
                PurchaseYear  = vehicleCreateDto.PurchaseYear,
                IsActive      = vehicleCreateDto.IsActive
            };

            await _vehicleRepository.AddVehicleAsync(vehicle);

            return (true, "Vehicle added successfully", MapToResponseDto(vehicle));
        }

        private static VehicleResponseDto MapToResponseDto(Vehicle vehicle) => new()
        {
            VehicleId     = vehicle.VehicleId,
            VehicleNumber = vehicle.VehicleNumber,
            VehicleType   = vehicle.VehicleType,
            Brand         = vehicle.Brand,
            Model         = vehicle.Model,
            PurchaseYear  = vehicle.PurchaseYear,
            IsActive      = vehicle.IsActive
        };
    }
}
