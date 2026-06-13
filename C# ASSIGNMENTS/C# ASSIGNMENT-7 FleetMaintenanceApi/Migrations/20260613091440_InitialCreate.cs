using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FleetMaintenanceApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PurchaseYear = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    ServiceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "City", "DriverName", "IsAvailable", "LicenseNumber", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Coimbatore", "Ramesh Kumar", true, "DL2026TN1001", "9876543210" },
                    { 2, "Chennai", "Suresh Babu", true, "DL2025TN1002", "9876543211" },
                    { 3, "Madurai", "Arjun Patel", false, "DL2024TN1003", "9876543212" },
                    { 4, "Salem", "Karthik Rajan", true, "DL2023TN1004", "9876543213" },
                    { 5, "Trichy", "Vijay Murugan", true, "DL2022TN1005", "9876543214" },
                    { 6, "Erode", "Dinesh Selvam", true, "DL2021TN1006", "9876543215" },
                    { 7, "Vellore", "Pradeep Nair", false, "DL2020TN1007", "9876543216" },
                    { 8, "Tirunelveli", "Manoj Krishnan", true, "DL2019TN1008", "9876543217" },
                    { 9, "Coimbatore", "Ravi Shankar", true, "DL2026TN1009", "9876543218" },
                    { 10, "Chennai", "Balaji Natarajan", true, "DL2025TN1010", "9876543219" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Brand", "IsActive", "Model", "PurchaseYear", "VehicleNumber", "VehicleType" },
                values: new object[,]
                {
                    { 1, "Tata", true, "Ace", 2021, "TN38AB1234", "Truck" },
                    { 2, "Ashok", true, "Leyland 10", 2020, "TN09CD5678", "Van" },
                    { 3, "Mahindra", true, "Blazo", 2019, "TN45EF9012", "Truck" },
                    { 4, "Tata", true, "Xenon", 2022, "TN22GH3456", "Pickup" },
                    { 5, "Eicher", true, "Pro 2049", 2021, "TN11IJ7890", "Mini Truck" },
                    { 6, "Force", false, "Traveller", 2020, "TN33KL2345", "Van" },
                    { 7, "BharatBenz", true, "1217C", 2023, "TN55MN6789", "Truck" },
                    { 8, "Isuzu", true, "D-Max", 2022, "TN77OP0123", "Pickup" },
                    { 9, "Tata", true, "407", 2018, "TN99QR4567", "Mini Truck" },
                    { 10, "Mahindra", true, "Supro", 2023, "TN66ST8901", "Van" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "MaintenanceId", "CreatedDate", "DriverId", "Remarks", "ServiceCost", "ServiceDate", "ServiceStatus", "ServiceType", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Regular oil replacement", 2500.00m, new DateOnly(2026, 1, 5), "Completed", "Oil Change", 1 },
                    { 2, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Brake pads replaced", 1800.00m, new DateOnly(2026, 1, 10), "Completed", "Brake Inspection", 2 },
                    { 3, new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Engine oil leak fixed", 15000.00m, new DateOnly(2026, 1, 15), "Completed", "Engine Repair", 3 },
                    { 4, new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "All four tyres replaced", 8000.00m, new DateOnly(2026, 2, 3), "Completed", "Tyre Replacement", 4 },
                    { 5, new DateTime(2026, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Battery terminals cleaned", 500.00m, new DateOnly(2026, 2, 8), "Completed", "Battery Check", 5 },
                    { 6, new DateTime(2026, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Full general service done", 3500.00m, new DateOnly(2026, 2, 12), "Completed", "General Service", 6 },
                    { 7, new DateTime(2026, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Synthetic oil used", 2800.00m, new DateOnly(2026, 2, 18), "Completed", "Oil Change", 7 },
                    { 8, new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Front brakes replaced", 2200.00m, new DateOnly(2026, 2, 22), "Completed", "Brake Inspection", 8 },
                    { 9, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Fuel pump replaced", 22000.00m, new DateOnly(2026, 3, 5), "Completed", "Engine Repair", 9 },
                    { 10, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Two rear tyres replaced", 6500.00m, new DateOnly(2026, 3, 10), "Completed", "Tyre Replacement", 10 },
                    { 11, new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Periodic service completed", 4000.00m, new DateOnly(2026, 3, 15), "Completed", "General Service", 1 },
                    { 12, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Battery replaced", 3200.00m, new DateOnly(2026, 3, 20), "Completed", "Battery Check", 2 },
                    { 13, new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Oil and filter changed", 2600.00m, new DateOnly(2026, 4, 2), "Completed", "Oil Change", 3 },
                    { 14, new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Brake fluid topped up", 1500.00m, new DateOnly(2026, 4, 7), "Completed", "Brake Inspection", 4 },
                    { 15, new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Undergoing scheduled service", 3800.00m, new DateOnly(2026, 4, 12), "InProgress", "General Service", 5 },
                    { 16, new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Coolant system repair ongoing", 18000.00m, new DateOnly(2026, 4, 18), "InProgress", "Engine Repair", 6 },
                    { 17, new DateTime(2026, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Front tyres replaced", 7500.00m, new DateOnly(2026, 4, 22), "Completed", "Tyre Replacement", 7 },
                    { 18, new DateTime(2026, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "High mileage oil used", 2700.00m, new DateOnly(2026, 5, 3), "Completed", "Oil Change", 8 },
                    { 19, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Battery health checked OK", 450.00m, new DateOnly(2026, 5, 8), "Completed", "Battery Check", 9 },
                    { 20, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Cancelled due to driver absence", 2000.00m, new DateOnly(2026, 5, 12), "Cancelled", "Brake Inspection", 10 },
                    { 21, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Rescheduled to next week", 4200.00m, new DateOnly(2026, 5, 17), "Cancelled", "General Service", 1 },
                    { 22, new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Injector cleaning done", 12000.00m, new DateOnly(2026, 5, 22), "Completed", "Engine Repair", 2 },
                    { 23, new DateTime(2026, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Routine oil change", 2500.00m, new DateOnly(2026, 5, 27), "Completed", "Oil Change", 3 },
                    { 24, new DateTime(2026, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "All tyres replaced due to wear", 9000.00m, new DateOnly(2026, 6, 2), "Completed", "Tyre Replacement", 4 },
                    { 25, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Battery replaced - weak charge", 600.00m, new DateOnly(2026, 6, 5), "Completed", "Battery Check", 5 },
                    { 26, new DateTime(2026, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Rear brake drum replacement", 1700.00m, new DateOnly(2026, 6, 8), "InProgress", "Brake Inspection", 6 },
                    { 27, new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Quarterly service due", 3600.00m, new DateOnly(2026, 6, 10), "Scheduled", "General Service", 7 },
                    { 28, new DateTime(2026, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Overdue oil change", 2900.00m, new DateOnly(2026, 6, 12), "Scheduled", "Oil Change", 8 },
                    { 29, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Major engine overhaul planned", 25000.00m, new DateOnly(2026, 6, 15), "Scheduled", "Engine Repair", 9 },
                    { 30, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "New tyres before monsoon season", 7000.00m, new DateOnly(2026, 6, 18), "Scheduled", "Tyre Replacement", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_DriverId",
                table: "MaintenanceRecords",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_VehicleId",
                table: "MaintenanceRecords",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
