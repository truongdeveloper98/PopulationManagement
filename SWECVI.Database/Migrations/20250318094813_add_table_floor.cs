using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWECVI.Database.Migrations
{
    /// <inheritdoc />
    public partial class add_table_floor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_FloorInformation_FloorInformationId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorInformation_BuildingInformations_BuildingInformationId",
                table: "FloorInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FloorInformation",
                table: "FloorInformation");

            migrationBuilder.DropIndex(
                name: "IX_FloorInformation_BuildingInformationId",
                table: "FloorInformation");

            migrationBuilder.DropColumn(
                name: "BuildingInformationId",
                table: "FloorInformation");

            migrationBuilder.RenameTable(
                name: "FloorInformation",
                newName: "FloorInformations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FloorInformations",
                table: "FloorInformations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FloorInformations_BuildingId",
                table: "FloorInformations",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_FloorInformations_FloorInformationId",
                table: "Apartment",
                column: "FloorInformationId",
                principalTable: "FloorInformations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorInformations_BuildingInformations_BuildingId",
                table: "FloorInformations",
                column: "BuildingId",
                principalTable: "BuildingInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartment_FloorInformations_FloorInformationId",
                table: "Apartment");

            migrationBuilder.DropForeignKey(
                name: "FK_FloorInformations_BuildingInformations_BuildingId",
                table: "FloorInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FloorInformations",
                table: "FloorInformations");

            migrationBuilder.DropIndex(
                name: "IX_FloorInformations_BuildingId",
                table: "FloorInformations");

            migrationBuilder.RenameTable(
                name: "FloorInformations",
                newName: "FloorInformation");

            migrationBuilder.AddColumn<int>(
                name: "BuildingInformationId",
                table: "FloorInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FloorInformation",
                table: "FloorInformation",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FloorInformation_BuildingInformationId",
                table: "FloorInformation",
                column: "BuildingInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartment_FloorInformation_FloorInformationId",
                table: "Apartment",
                column: "FloorInformationId",
                principalTable: "FloorInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FloorInformation_BuildingInformations_BuildingInformationId",
                table: "FloorInformation",
                column: "BuildingInformationId",
                principalTable: "BuildingInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
