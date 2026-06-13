using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Models;
using FleetMaintenanceApi.Repositories.Interfaces;
using FleetMaintenanceApi.Services.Interfaces;

namespace FleetMaintenanceApi.Services.Implementations
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<List<DriverResponseDto>> GetAllDriversAsync()
        {
            var drivers = await _driverRepository.GetAllDriversAsync();
            return drivers.Select(MapToResponseDto).ToList();
        }

        public async Task<DriverResponseDto?> GetDriverByIdAsync(int driverId)
        {
            var driver = await _driverRepository.GetDriverByIdAsync(driverId);
            return driver == null ? null : MapToResponseDto(driver);
        }

        public async Task<(bool Success, string Message, DriverResponseDto? Data)>
            AddDriverAsync(DriverCreateDto driverCreateDto)
        {
            var driver = new Driver
            {
                DriverName    = driverCreateDto.DriverName,
                LicenseNumber = driverCreateDto.LicenseNumber,
                PhoneNumber   = driverCreateDto.PhoneNumber,
                City          = driverCreateDto.City,
                IsAvailable   = driverCreateDto.IsAvailable
            };

            await _driverRepository.AddDriverAsync(driver);

            return (true, "Driver added successfully", MapToResponseDto(driver));
        }

        private static DriverResponseDto MapToResponseDto(Driver driver) => new()
        {
            DriverId      = driver.DriverId,
            DriverName    = driver.DriverName,
            LicenseNumber = driver.LicenseNumber,
            PhoneNumber   = driver.PhoneNumber,
            City          = driver.City,
            IsAvailable   = driver.IsAvailable
        };
    }
}
