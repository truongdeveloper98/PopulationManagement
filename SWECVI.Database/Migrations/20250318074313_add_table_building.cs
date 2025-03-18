using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWECVI.Database.Migrations
{
    /// <inheritdoc />
    public partial class add_table_building : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCommentStatus",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotifyStatus",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsReceiveJobStatus",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStatus",
                table: "Department",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BuildingInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfObject = table.Column<int>(type: "int", nullable: false),
                    TypeOfService = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cycle = table.Column<int>(type: "int", nullable: false),
                    PayDate = table.Column<int>(type: "int", nullable: false),
                    FirstDate = table.Column<int>(type: "int", nullable: false),
                    StartPriceCaculationMethod = table.Column<int>(type: "int", nullable: false),
                    EndPriceCaculationMethod = table.Column<int>(type: "int", nullable: false),
                    ApplyFrom = table.Column<int>(type: "int", nullable: false),
                    SwitchDay = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FloorInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    BuildingInformationId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FloorInformation_BuildingInformations_BuildingInformationId",
                        column: x => x.BuildingInformationId,
                        principalTable: "BuildingInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false),
                    ElectricId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfBedroom = table.Column<int>(type: "int", nullable: false),
                    ApplicationFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BuildingInformationId = table.Column<int>(type: "int", nullable: true),
                    FloorInformationId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartment_BuildingInformations_BuildingInformationId",
                        column: x => x.BuildingInformationId,
                        principalTable: "BuildingInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartment_FloorInformation_FloorInformationId",
                        column: x => x.FloorInformationId,
                        principalTable: "FloorInformation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApartmentInService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentInService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentInService_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApartmentInService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleOfApartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Relationship = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleOfApartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleOfApartment_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleOfApartment_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfVehice = table.Column<int>(type: "int", nullable: false),
                    NumberPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    VehicleCardId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    VehicleOwnerId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ApplyFeeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndFeeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeeLevel = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_BuildingInformations_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "BuildingInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleCardCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfVehicle = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleId1 = table.Column<int>(type: "int", nullable: true),
                    BuildingInformationId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleCard_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleCard_BuildingInformations_BuildingInformationId",
                        column: x => x.BuildingInformationId,
                        principalTable: "BuildingInformations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleCard_Vehicle_VehicleId1",
                        column: x => x.VehicleId1,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_ServiceId",
                table: "Department",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_BuildingInformationId",
                table: "Apartment",
                column: "BuildingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_CustomerId",
                table: "Apartment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_FloorInformationId",
                table: "Apartment",
                column: "FloorInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentInService_ApartmentId",
                table: "ApartmentInService",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentInService_ServiceId",
                table: "ApartmentInService",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_FloorInformation_BuildingInformationId",
                table: "FloorInformation",
                column: "BuildingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleOfApartment_ApartmentId",
                table: "PeopleOfApartment",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleOfApartment_AppUserId",
                table: "PeopleOfApartment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepartmentId",
                table: "Staff",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ApartmentId",
                table: "Vehicle",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_AppUserId",
                table: "Vehicle",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BuildingId",
                table: "Vehicle",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ServiceId",
                table: "Vehicle",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCard_ApartmentId",
                table: "VehicleCard",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCard_BuildingInformationId",
                table: "VehicleCard",
                column: "BuildingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCard_VehicleId1",
                table: "VehicleCard",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Service_ServiceId",
                table: "Department",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Service_ServiceId",
                table: "Department");

            migrationBuilder.DropTable(
                name: "ApartmentInService");

            migrationBuilder.DropTable(
                name: "PeopleOfApartment");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "VehicleCard");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "FloorInformation");

            migrationBuilder.DropTable(
                name: "BuildingInformations");

            migrationBuilder.DropIndex(
                name: "IX_Department_ServiceId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "IsCommentStatus",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "IsNotifyStatus",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "IsReceiveJobStatus",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "IsStatus",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Department");
        }
    }
}
