using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWECVI.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_tb_priceList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ApartmentName",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PeopleOfApartments");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PeopleOfApartments");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "HospitalUsers",
                newName: "PhoneNumberUser");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "HospitalUsers",
                newName: "EmailUser");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "PriceLists",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ServiceId",
                table: "PriceLists",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceLists_Services_ServiceId",
                table: "PriceLists",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceLists_Services_ServiceId",
                table: "PriceLists");

            migrationBuilder.DropIndex(
                name: "IX_PriceLists_ServiceId",
                table: "PriceLists");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "PriceLists");

            migrationBuilder.RenameColumn(
                name: "PhoneNumberUser",
                table: "HospitalUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "EmailUser",
                table: "HospitalUsers",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApartmentName",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PeopleOfApartments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PeopleOfApartments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
