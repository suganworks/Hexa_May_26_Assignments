using Microsoft.EntityFrameworkCore;
using FleetMaintenanceApi.Models;

namespace FleetMaintenanceApi.Data
{
    public class FleetMaintenanceDbContext : DbContext
    {
        public FleetMaintenanceDbContext(DbContextOptions<FleetMaintenanceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MaintenanceRecord>()
                .HasOne(m => m.Vehicle)
                .WithMany(v => v.MaintenanceRecords)
                .HasForeignKey(m => m.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MaintenanceRecord>()
                .HasOne(m => m.Driver)
                .WithMany(d => d.MaintenanceRecords)
                .HasForeignKey(m => m.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Vehicles (10)
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1,  VehicleNumber = "TN38AB1234", VehicleType = "Truck",      Brand = "Tata",       Model = "Ace",        PurchaseYear = 2021, IsActive = true  },
                new Vehicle { VehicleId = 2,  VehicleNumber = "TN09CD5678", VehicleType = "Van",        Brand = "Ashok",      Model = "Leyland 10", PurchaseYear = 2020, IsActive = true  },
                new Vehicle { VehicleId = 3,  VehicleNumber = "TN45EF9012", VehicleType = "Truck",      Brand = "Mahindra",   Model = "Blazo",      PurchaseYear = 2019, IsActive = true  },
                new Vehicle { VehicleId = 4,  VehicleNumber = "TN22GH3456", VehicleType = "Pickup",     Brand = "Tata",       Model = "Xenon",      PurchaseYear = 2022, IsActive = true  },
                new Vehicle { VehicleId = 5,  VehicleNumber = "TN11IJ7890", VehicleType = "Mini Truck", Brand = "Eicher",     Model = "Pro 2049",   PurchaseYear = 2021, IsActive = true  },
                new Vehicle { VehicleId = 6,  VehicleNumber = "TN33KL2345", VehicleType = "Van",        Brand = "Force",      Model = "Traveller",  PurchaseYear = 2020, IsActive = false },
                new Vehicle { VehicleId = 7,  VehicleNumber = "TN55MN6789", VehicleType = "Truck",      Brand = "BharatBenz", Model = "1217C",      PurchaseYear = 2023, IsActive = true  },
                new Vehicle { VehicleId = 8,  VehicleNumber = "TN77OP0123", VehicleType = "Pickup",     Brand = "Isuzu",      Model = "D-Max",      PurchaseYear = 2022, IsActive = true  },
                new Vehicle { VehicleId = 9,  VehicleNumber = "TN99QR4567", VehicleType = "Mini Truck", Brand = "Tata",       Model = "407",        PurchaseYear = 2018, IsActive = true  },
                new Vehicle { VehicleId = 10, VehicleNumber = "TN66ST8901", VehicleType = "Van",        Brand = "Mahindra",   Model = "Supro",      PurchaseYear = 2023, IsActive = true  }
            );

            // Seed Drivers (10)
            modelBuilder.Entity<Driver>().HasData(
                new Driver { DriverId = 1,  DriverName = "Ramesh Kumar",     LicenseNumber = "DL2026TN1001", PhoneNumber = "9876543210", City = "Coimbatore",  IsAvailable = true  },
                new Driver { DriverId = 2,  DriverName = "Suresh Babu",      LicenseNumber = "DL2025TN1002", PhoneNumber = "9876543211", City = "Chennai",     IsAvailable = true  },
                new Driver { DriverId = 3,  DriverName = "Arjun Patel",      LicenseNumber = "DL2024TN1003", PhoneNumber = "9876543212", City = "Madurai",     IsAvailable = false },
                new Driver { DriverId = 4,  DriverName = "Karthik Rajan",    LicenseNumber = "DL2023TN1004", PhoneNumber = "9876543213", City = "Salem",       IsAvailable = true  },
                new Driver { DriverId = 5,  DriverName = "Vijay Murugan",    LicenseNumber = "DL2022TN1005", PhoneNumber = "9876543214", City = "Trichy",      IsAvailable = true  },
                new Driver { DriverId = 6,  DriverName = "Dinesh Selvam",    LicenseNumber = "DL2021TN1006", PhoneNumber = "9876543215", City = "Erode",       IsAvailable = true  },
                new Driver { DriverId = 7,  DriverName = "Pradeep Nair",     LicenseNumber = "DL2020TN1007", PhoneNumber = "9876543216", City = "Vellore",     IsAvailable = false },
                new Driver { DriverId = 8,  DriverName = "Manoj Krishnan",   LicenseNumber = "DL2019TN1008", PhoneNumber = "9876543217", City = "Tirunelveli", IsAvailable = true  },
                new Driver { DriverId = 9,  DriverName = "Ravi Shankar",     LicenseNumber = "DL2026TN1009", PhoneNumber = "9876543218", City = "Coimbatore",  IsAvailable = true  },
                new Driver { DriverId = 10, DriverName = "Balaji Natarajan", LicenseNumber = "DL2025TN1010", PhoneNumber = "9876543219", City = "Chennai",     IsAvailable = true  }
            );

            // Seed MaintenanceRecords (30)
            modelBuilder.Entity<MaintenanceRecord>().HasData(
                new MaintenanceRecord { MaintenanceId = 1,  VehicleId = 1,  DriverId = 1,  ServiceDate = new DateOnly(2026, 1, 5),  ServiceType = "Oil Change",       ServiceCost = 2500.00m,  ServiceStatus = "Completed",  Remarks = "Regular oil replacement",        CreatedDate = new DateTime(2026, 1, 1)   },
                new MaintenanceRecord { MaintenanceId = 2,  VehicleId = 2,  DriverId = 2,  ServiceDate = new DateOnly(2026, 1, 10), ServiceType = "Brake Inspection",  ServiceCost = 1800.00m,  ServiceStatus = "Completed",  Remarks = "Brake pads replaced",            CreatedDate = new DateTime(2026, 1, 5)   },
                new MaintenanceRecord { MaintenanceId = 3,  VehicleId = 3,  DriverId = 3,  ServiceDate = new DateOnly(2026, 1, 15), ServiceType = "Engine Repair",     ServiceCost = 15000.00m, ServiceStatus = "Completed",  Remarks = "Engine oil leak fixed",          CreatedDate = new DateTime(2026, 1, 10)  },
                new MaintenanceRecord { MaintenanceId = 4,  VehicleId = 4,  DriverId = 4,  ServiceDate = new DateOnly(2026, 2, 3),  ServiceType = "Tyre Replacement",  ServiceCost = 8000.00m,  ServiceStatus = "Completed",  Remarks = "All four tyres replaced",        CreatedDate = new DateTime(2026, 1, 28)  },
                new MaintenanceRecord { MaintenanceId = 5,  VehicleId = 5,  DriverId = 5,  ServiceDate = new DateOnly(2026, 2, 8),  ServiceType = "Battery Check",     ServiceCost = 500.00m,   ServiceStatus = "Completed",  Remarks = "Battery terminals cleaned",      CreatedDate = new DateTime(2026, 2, 3)   },
                new MaintenanceRecord { MaintenanceId = 6,  VehicleId = 6,  DriverId = 6,  ServiceDate = new DateOnly(2026, 2, 12), ServiceType = "General Service",   ServiceCost = 3500.00m,  ServiceStatus = "Completed",  Remarks = "Full general service done",      CreatedDate = new DateTime(2026, 2, 7)   },
                new MaintenanceRecord { MaintenanceId = 7,  VehicleId = 7,  DriverId = 7,  ServiceDate = new DateOnly(2026, 2, 18), ServiceType = "Oil Change",        ServiceCost = 2800.00m,  ServiceStatus = "Completed",  Remarks = "Synthetic oil used",             CreatedDate = new DateTime(2026, 2, 13)  },
                new MaintenanceRecord { MaintenanceId = 8,  VehicleId = 8,  DriverId = 8,  ServiceDate = new DateOnly(2026, 2, 22), ServiceType = "Brake Inspection",  ServiceCost = 2200.00m,  ServiceStatus = "Completed",  Remarks = "Front brakes replaced",          CreatedDate = new DateTime(2026, 2, 17)  },
                new MaintenanceRecord { MaintenanceId = 9,  VehicleId = 9,  DriverId = 9,  ServiceDate = new DateOnly(2026, 3, 5),  ServiceType = "Engine Repair",     ServiceCost = 22000.00m, ServiceStatus = "Completed",  Remarks = "Fuel pump replaced",             CreatedDate = new DateTime(2026, 3, 1)   },
                new MaintenanceRecord { MaintenanceId = 10, VehicleId = 10, DriverId = 10, ServiceDate = new DateOnly(2026, 3, 10), ServiceType = "Tyre Replacement",  ServiceCost = 6500.00m,  ServiceStatus = "Completed",  Remarks = "Two rear tyres replaced",        CreatedDate = new DateTime(2026, 3, 5)   },
                new MaintenanceRecord { MaintenanceId = 11, VehicleId = 1,  DriverId = 2,  ServiceDate = new DateOnly(2026, 3, 15), ServiceType = "General Service",   ServiceCost = 4000.00m,  ServiceStatus = "Completed",  Remarks = "Periodic service completed",     CreatedDate = new DateTime(2026, 3, 10)  },
                new MaintenanceRecord { MaintenanceId = 12, VehicleId = 2,  DriverId = 3,  ServiceDate = new DateOnly(2026, 3, 20), ServiceType = "Battery Check",     ServiceCost = 3200.00m,  ServiceStatus = "Completed",  Remarks = "Battery replaced",               CreatedDate = new DateTime(2026, 3, 15)  },
                new MaintenanceRecord { MaintenanceId = 13, VehicleId = 3,  DriverId = 4,  ServiceDate = new DateOnly(2026, 4, 2),  ServiceType = "Oil Change",        ServiceCost = 2600.00m,  ServiceStatus = "Completed",  Remarks = "Oil and filter changed",         CreatedDate = new DateTime(2026, 3, 28)  },
                new MaintenanceRecord { MaintenanceId = 14, VehicleId = 4,  DriverId = 5,  ServiceDate = new DateOnly(2026, 4, 7),  ServiceType = "Brake Inspection",  ServiceCost = 1500.00m,  ServiceStatus = "Completed",  Remarks = "Brake fluid topped up",          CreatedDate = new DateTime(2026, 4, 2)   },
                new MaintenanceRecord { MaintenanceId = 15, VehicleId = 5,  DriverId = 6,  ServiceDate = new DateOnly(2026, 4, 12), ServiceType = "General Service",   ServiceCost = 3800.00m,  ServiceStatus = "InProgress", Remarks = "Undergoing scheduled service",   CreatedDate = new DateTime(2026, 4, 7)   },
                new MaintenanceRecord { MaintenanceId = 16, VehicleId = 6,  DriverId = 7,  ServiceDate = new DateOnly(2026, 4, 18), ServiceType = "Engine Repair",     ServiceCost = 18000.00m, ServiceStatus = "InProgress", Remarks = "Coolant system repair ongoing",  CreatedDate = new DateTime(2026, 4, 13)  },
                new MaintenanceRecord { MaintenanceId = 17, VehicleId = 7,  DriverId = 8,  ServiceDate = new DateOnly(2026, 4, 22), ServiceType = "Tyre Replacement",  ServiceCost = 7500.00m,  ServiceStatus = "Completed",  Remarks = "Front tyres replaced",           CreatedDate = new DateTime(2026, 4, 17)  },
                new MaintenanceRecord { MaintenanceId = 18, VehicleId = 8,  DriverId = 9,  ServiceDate = new DateOnly(2026, 5, 3),  ServiceType = "Oil Change",        ServiceCost = 2700.00m,  ServiceStatus = "Completed",  Remarks = "High mileage oil used",          CreatedDate = new DateTime(2026, 4, 28)  },
                new MaintenanceRecord { MaintenanceId = 19, VehicleId = 9,  DriverId = 10, ServiceDate = new DateOnly(2026, 5, 8),  ServiceType = "Battery Check",     ServiceCost = 450.00m,   ServiceStatus = "Completed",  Remarks = "Battery health checked OK",      CreatedDate = new DateTime(2026, 5, 3)   },
                new MaintenanceRecord { MaintenanceId = 20, VehicleId = 10, DriverId = 1,  ServiceDate = new DateOnly(2026, 5, 12), ServiceType = "Brake Inspection",  ServiceCost = 2000.00m,  ServiceStatus = "Cancelled",  Remarks = "Cancelled due to driver absence", CreatedDate = new DateTime(2026, 5, 7)  },
                new MaintenanceRecord { MaintenanceId = 21, VehicleId = 1,  DriverId = 3,  ServiceDate = new DateOnly(2026, 5, 17), ServiceType = "General Service",   ServiceCost = 4200.00m,  ServiceStatus = "Cancelled",  Remarks = "Rescheduled to next week",       CreatedDate = new DateTime(2026, 5, 12)  },
                new MaintenanceRecord { MaintenanceId = 22, VehicleId = 2,  DriverId = 4,  ServiceDate = new DateOnly(2026, 5, 22), ServiceType = "Engine Repair",     ServiceCost = 12000.00m, ServiceStatus = "Completed",  Remarks = "Injector cleaning done",         CreatedDate = new DateTime(2026, 5, 17)  },
                new MaintenanceRecord { MaintenanceId = 23, VehicleId = 3,  DriverId = 5,  ServiceDate = new DateOnly(2026, 5, 27), ServiceType = "Oil Change",        ServiceCost = 2500.00m,  ServiceStatus = "Completed",  Remarks = "Routine oil change",             CreatedDate = new DateTime(2026, 5, 22)  },
                new MaintenanceRecord { MaintenanceId = 24, VehicleId = 4,  DriverId = 6,  ServiceDate = new DateOnly(2026, 6, 2),  ServiceType = "Tyre Replacement",  ServiceCost = 9000.00m,  ServiceStatus = "Completed",  Remarks = "All tyres replaced due to wear", CreatedDate = new DateTime(2026, 5, 28)  },
                new MaintenanceRecord { MaintenanceId = 25, VehicleId = 5,  DriverId = 7,  ServiceDate = new DateOnly(2026, 6, 5),  ServiceType = "Battery Check",     ServiceCost = 600.00m,   ServiceStatus = "Completed",  Remarks = "Battery replaced - weak charge",  CreatedDate = new DateTime(2026, 6, 1)  },
                new MaintenanceRecord { MaintenanceId = 26, VehicleId = 6,  DriverId = 8,  ServiceDate = new DateOnly(2026, 6, 8),  ServiceType = "Brake Inspection",  ServiceCost = 1700.00m,  ServiceStatus = "InProgress", Remarks = "Rear brake drum replacement",    CreatedDate = new DateTime(2026, 6, 3)   },
                new MaintenanceRecord { MaintenanceId = 27, VehicleId = 7,  DriverId = 9,  ServiceDate = new DateOnly(2026, 6, 10), ServiceType = "General Service",   ServiceCost = 3600.00m,  ServiceStatus = "Scheduled",  Remarks = "Quarterly service due",          CreatedDate = new DateTime(2026, 6, 5)   },
                new MaintenanceRecord { MaintenanceId = 28, VehicleId = 8,  DriverId = 10, ServiceDate = new DateOnly(2026, 6, 12), ServiceType = "Oil Change",        ServiceCost = 2900.00m,  ServiceStatus = "Scheduled",  Remarks = "Overdue oil change",             CreatedDate = new DateTime(2026, 6, 7)   },
                new MaintenanceRecord { MaintenanceId = 29, VehicleId = 9,  DriverId = 1,  ServiceDate = new DateOnly(2026, 6, 15), ServiceType = "Engine Repair",     ServiceCost = 25000.00m, ServiceStatus = "Scheduled",  Remarks = "Major engine overhaul planned",  CreatedDate = new DateTime(2026, 6, 10)  },
                new MaintenanceRecord { MaintenanceId = 30, VehicleId = 10, DriverId = 2,  ServiceDate = new DateOnly(2026, 6, 18), ServiceType = "Tyre Replacement",  ServiceCost = 7000.00m,  ServiceStatus = "Scheduled",  Remarks = "New tyres before monsoon season", CreatedDate = new DateTime(2026, 6, 12) }
            );
        }
    }
}
