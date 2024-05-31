using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "User",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userId", "email", "firstName", "lastName", "password", "role", "salt" },
                values: new object[] { new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"), null, "Valcon", "Admin", "ZoG05mNx76EFRSOm9MeWuYFGOOZVo25EjQltikW5epDnkOwPRAY2fSxWrOhZGI0FJYSAgZNQe+LVHkQHKap4r8ADTDFpyxc9GaeKVHnMjz2tCheZ4PcyXsqdsILiiDbxsD/OFVtQxxQxEgOqUVNfZ07/zfd3/v6cVQ60H880UdLW+AhWtQ5WidhawvOD4tMRzl4j3V3n9DctzsSC0VtR6Ii+jLCsAPOejgcWSCYohOFjLhoAgA0iUHjMGgIrwyYNHGvHUnk1Mhtq0dvA4WVzjeX5BTM/xIpALgHtu+YLFGiEfwzQfBozgZpRyzCbc4WUcVcl1IIy1z2R54XSxWpCcg==", "Admin", "HREjDgrlaXzC+A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"));

            migrationBuilder.DropColumn(
                name: "role",
                table: "User");
        }
    }
}
