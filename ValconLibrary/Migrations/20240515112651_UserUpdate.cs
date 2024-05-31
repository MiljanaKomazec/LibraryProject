using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userName",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "User",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "User",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
