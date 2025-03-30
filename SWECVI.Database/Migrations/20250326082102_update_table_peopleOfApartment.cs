using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWECVI.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_table_peopleOfApartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleOfApartments_AspNetUsers_AppUserId",
                table: "PeopleOfApartments");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleOfApartments_HospitalUsers_AppUserId",
                table: "PeopleOfApartments",
                column: "AppUserId",
                principalTable: "HospitalUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleOfApartments_HospitalUsers_AppUserId",
                table: "PeopleOfApartments");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleOfApartments_AspNetUsers_AppUserId",
                table: "PeopleOfApartments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
