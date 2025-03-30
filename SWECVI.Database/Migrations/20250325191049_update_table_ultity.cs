using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWECVI.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_table_ultity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_AspNetUsers_CustomerId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_BuildingInformations_BuildingInformationId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_FloorInformations_FloorInformationId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentInService_Apartment_ApartmentId",
                table: "ApartmentInService");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentInService_Service_ServiceId",
                table: "ApartmentInService");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_AspNetUsers_DepartmentManagerId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Service_ServiceId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleOfApartment_Apartment_ApartmentId",
                table: "PeopleOfApartment");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleOfApartment_AspNetUsers_AppUserId",
                table: "PeopleOfApartment");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Apartment_ApartmentId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_AspNetUsers_AppUserId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_BuildingInformations_BuildingId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Service_ServiceId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleCard_Apartment_ApartmentId",
                table: "VehicleCard");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleCard_BuildingInformations_BuildingInformationId",
                table: "VehicleCard");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleCard_Vehicle_VehicleId1",
                table: "VehicleCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Department_ServiceId",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleCard",
                table: "VehicleCard");

            migrationBuilder.DropIndex(
                name: "IX_VehicleCard_ApartmentId",
                table: "VehicleCard");

            migrationBuilder.DropIndex(
                name: "IX_VehicleCard_BuildingInformationId",
                table: "VehicleCard");

            migrationBuilder.DropIndex(
                name: "IX_VehicleCard_VehicleId1",
                table: "VehicleCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_BuildingId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleOfApartment",
                table: "PeopleOfApartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentInService",
                table: "ApartmentInService");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartment",
                table: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_BuildingInformationId",
                table: "Apartment");

            migrationBuilder.DropIndex(
                name: "IX_Apartment_FloorInformationId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "VehicleCard");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "VehicleCard");

            migrationBuilder.DropColumn(
                name: "BuildingInformationId",
                table: "VehicleCard");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "VehicleCard");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "ApartmentInService");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "BuildingInformationId",
                table: "Apartment");

            migrationBuilder.DropColumn(
                name: "FloorInformationId",
                table: "Apartment");

            migrationBuilder.RenameTable(
                name: "VehicleCard",
                newName: "VehicleCards");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "PeopleOfApartment",
                newName: "PeopleOfApartments");

            migrationBuilder.RenameTable(
                name: "ApartmentInService",
                newName: "ApartmentInServices");

            migrationBuilder.RenameTable(
                name: "Apartment",
                newName: "Apartments");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "VehicleCards",
                newName: "VehicleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_ServiceId",
                table: "Vehicles",
                newName: "IX_Vehicles_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_AppUserId",
                table: "Vehicles",
                newName: "IX_Vehicles_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_ApartmentId",
                table: "Vehicles",
                newName: "IX_Vehicles_ApartmentId");

            migrationBuilder.RenameColumn(
                name: "DepartmentName",
                table: "Services",
                newName: "ApartmentName");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Services",
                newName: "ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PeopleOfApartment_AppUserId",
                table: "PeopleOfApartments",
                newName: "IX_PeopleOfApartments_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PeopleOfApartment_ApartmentId",
                table: "PeopleOfApartments",
                newName: "IX_PeopleOfApartments_ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentInService_ServiceId",
                table: "ApartmentInServices",
                newName: "IX_ApartmentInServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentInService_ApartmentId",
                table: "ApartmentInServices",
                newName: "IX_ApartmentInServices_ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartment_CustomerId",
                table: "Apartments",
                newName: "IX_Apartments_CustomerId");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "StartTime",
                table: "Ultity",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EndTime",
                table: "Ultity",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Staff",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Staff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Staff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StaffCode",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Staff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentManagerId",
                table: "Department",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "ApartmentInServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleCards",
                table: "VehicleCards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleOfApartments",
                table: "PeopleOfApartments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentInServices",
                table: "ApartmentInServices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DocumentOfApartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentOfApartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceListCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TypeOfFee = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCards_VehicleEntityId",
                table: "VehicleCards",
                column: "VehicleEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_FloorId",
                table: "Apartments",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentInServices_Apartments_ApartmentId",
                table: "ApartmentInServices",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentInServices_Services_ServiceId",
                table: "ApartmentInServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_AspNetUsers_CustomerId",
                table: "Apartments",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_FloorInformations_FloorId",
                table: "Apartments",
                column: "FloorId",
                principalTable: "FloorInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_AspNetUsers_DepartmentManagerId",
                table: "Department",
                column: "DepartmentManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleOfApartments_Apartments_ApartmentId",
                table: "PeopleOfApartments",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleOfApartments_AspNetUsers_AppUserId",
                table: "PeopleOfApartments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleCards_Vehicles_VehicleEntityId",
                table: "VehicleCards",
                column: "VehicleEntityId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Apartments_ApartmentId",
                table: "Vehicles",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_AppUserId",
                table: "Vehicles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Services_ServiceId",
                table: "Vehicles",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentInServices_Apartments_ApartmentId",
                table: "ApartmentInServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentInServices_Services_ServiceId",
                table: "ApartmentInServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_AspNetUsers_CustomerId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_FloorInformations_FloorId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_AspNetUsers_DepartmentManagerId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleOfApartments_Apartments_ApartmentId",
                table: "PeopleOfApartments");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleOfApartments_AspNetUsers_AppUserId",
                table: "PeopleOfApartments");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleCards_Vehicles_VehicleEntityId",
                table: "VehicleCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Apartments_ApartmentId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_AppUserId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Services_ServiceId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "DocumentOfApartments");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleCards",
                table: "VehicleCards");

            migrationBuilder.DropIndex(
                name: "IX_VehicleCards_VehicleEntityId",
                table: "VehicleCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleOfApartments",
                table: "PeopleOfApartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Apartments",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_FloorId",
                table: "Apartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentInServices",
                table: "ApartmentInServices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "StaffCode",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "VehicleCards",
                newName: "VehicleCard");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "PeopleOfApartments",
                newName: "PeopleOfApartment");

            migrationBuilder.RenameTable(
                name: "Apartments",
                newName: "Apartment");

            migrationBuilder.RenameTable(
                name: "ApartmentInServices",
                newName: "ApartmentInService");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ServiceId",
                table: "Vehicle",
                newName: "IX_Vehicle_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_AppUserId",
                table: "Vehicle",
                newName: "IX_Vehicle_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ApartmentId",
                table: "Vehicle",
                newName: "IX_Vehicle_ApartmentId");

            migrationBuilder.RenameColumn(
                name: "VehicleEntityId",
                table: "VehicleCard",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "ApartmentName",
                table: "Service",
                newName: "DepartmentName");

            migrationBuilder.RenameColumn(
                name: "ApartmentId",
                table: "Service",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PeopleOfApartments_AppUserId",
                table: "PeopleOfApartment",
                newName: "IX_PeopleOfApartment_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PeopleOfApartments_ApartmentId",
                table: "PeopleOfApartment",
                newName: "IX_PeopleOfApartment_ApartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Apartments_CustomerId",
                table: "Apartment",
                newName: "IX_Apartment_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentInServices_ServiceId",
                table: "ApartmentInService",
                newName: "IX_ApartmentInService_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentInServices_ApartmentId",
                table: "ApartmentInService",
                newName: "IX_ApartmentInService_ApartmentId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Ultity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Ultity",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<string>(
                name: "StaffId",
                table: "Staff",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentManagerId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "VehicleCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "VehicleCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuildingInformationId",
                table: "VehicleCard",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId1",
                table: "VehicleCard",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "Apartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuildingInformationId",
                table: "Apartment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorInformationId",
                table: "Apartment",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "ApartmentInService",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "ApartmentInService",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "StaffId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleCard",
                table: "VehicleCard",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleOfApartment",
                table: "PeopleOfApartment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apartment",
                table: "Apartment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentInService",
                table: "ApartmentInService",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Department_ServiceId",
                table: "Department",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BuildingId",
                table: "Vehicle",
                column: "BuildingId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_BuildingInformationId",
                table: "Apartment",
                column: "BuildingInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_FloorInformationId",
                table: "Apartment",
                column: "FloorInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_AspNetUsers_CustomerId",
                table: "Apartment",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_BuildingInformations_BuildingInformationId",
                table: "Apartment",
                column: "BuildingInformationId",
                principalTable: "BuildingInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_FloorInformations_FloorInformationId",
                table: "Apartment",
                column: "FloorInformationId",
                principalTable: "FloorInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentInService_Apartment_ApartmentId",
                table: "ApartmentInService",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentInService_Service_ServiceId",
                table: "ApartmentInService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_AspNetUsers_DepartmentManagerId",
                table: "Department",
                column: "DepartmentManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Service_ServiceId",
                table: "Department",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleOfApartment_Apartment_ApartmentId",
                table: "PeopleOfApartment",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleOfApartment_AspNetUsers_AppUserId",
                table: "PeopleOfApartment",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Apartment_ApartmentId",
                table: "Vehicle",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_AspNetUsers_AppUserId",
                table: "Vehicle",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_BuildingInformations_BuildingId",
                table: "Vehicle",
                column: "BuildingId",
                principalTable: "BuildingInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Service_ServiceId",
                table: "Vehicle",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleCard_Apartment_ApartmentId",
                table: "VehicleCard",
                column: "ApartmentId",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleCard_BuildingInformations_BuildingInformationId",
                table: "VehicleCard",
                column: "BuildingInformationId",
                principalTable: "BuildingInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleCard_Vehicle_VehicleId1",
                table: "VehicleCard",
                column: "VehicleId1",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }
    }
}
