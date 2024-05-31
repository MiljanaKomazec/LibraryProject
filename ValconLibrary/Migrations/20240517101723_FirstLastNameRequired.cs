using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class FirstLastNameRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "CAOu6dIxm6+fxlcbg2mzhYJ658lLAScG9cU4jIhrzWPrxIhjhGoTZqyopjXQKG2fkiBfo5NMSWjDi4lJyWgGskMVVxQ8TeZqWVpDliLUAhuWBGQ6t7u6Rgtp/ZWWX+XUpkhl/RN2hRT2K7g+epJhWhEoXi5iryKU93OhZ/weAAF03c6hvzAfYaNjZXV+rnzObPDtRIdZOnhpoCFNlMuv00htEuDaPWgezwdHOoyRkcREXCUlm5rHjylrDfHNIFoRXIEU/eLOsHW4Lni6qnW7F5dQAN4zEOsdYhpdofFnnxgLyWXiEHg0jWk5FTCjpNBsVKCogoaoh8p1eQ5UQZ/dtA==", "KW++6c2u4yn5og==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "lastName",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "firstName",
                table: "Users",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "LG6fHCan3NnpzBrWiBJebC/WQcKI8jTwZ+zM5/HBITlN5CuTK5+Zdcy4ILEWl+tVjLUn6esa8AkVW1j2O1/FuDXYxqWKKnOcF8Soy+eMFCzzJQBYSAyJiyMyR/PYw8hQH7HpjLxdXNZ1dF+IIpFMEiaR8hve0MQgP0VZVLrc8ZcyoOw/n2FPUdKRNnMFTR7jBvzq+W4zh/ADubWEjFN+klgaIqSNZ6wS+SKYh9LSOCv05mX3GtHkTydyopqIaiI4ajSUIuplkpzRkF9uUPDQMGRm2x/MrXmvU1UVm6Uw219b6TD6JdIa1pvkghHqVNIZJvo0YmDKHYOCODbSaWDbSg==", "NQJATijgMAkZvw==" });
        }
    }
}
