using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWECVI.Database.Migrations
{
    /// <inheritdoc />
    public partial class update_table_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "HospitalUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "HospitalUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "HospitalUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "HospitalUsers");
        }
    }
}
