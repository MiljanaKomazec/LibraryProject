using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class UserToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "userId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "LG6fHCan3NnpzBrWiBJebC/WQcKI8jTwZ+zM5/HBITlN5CuTK5+Zdcy4ILEWl+tVjLUn6esa8AkVW1j2O1/FuDXYxqWKKnOcF8Soy+eMFCzzJQBYSAyJiyMyR/PYw8hQH7HpjLxdXNZ1dF+IIpFMEiaR8hve0MQgP0VZVLrc8ZcyoOw/n2FPUdKRNnMFTR7jBvzq+W4zh/ADubWEjFN+klgaIqSNZ6wS+SKYh9LSOCv05mX3GtHkTydyopqIaiI4ajSUIuplkpzRkF9uUPDQMGRm2x/MrXmvU1UVm6Uw219b6TD6JdIa1pvkghHqVNIZJvo0YmDKHYOCODbSaWDbSg==", "NQJATijgMAkZvw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "userId");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "P+03CZXQwPidLMjuoV7B26iBaL0PlwlfdHZz3cP4WTZuoAjZbe5MqJCtruLZnq0rQkxJ0eu/EaQq2FLQqEgdkdGXXrL6xwtnsH3bgMVvwaxMtAVyz1/hircUxg2xNgOi4CukRhUW/94BKkdVpXqbQHyue0cwWKd5jHY3Lv8xBqh0GxvFdMWYwHz28JS6Japbpm3nw0R/bFp96AKMCHDdSWrzhS/FLMvorMOgjPMjpxvPrsRXC8YacL6r469uxXWBwPhig1bgS5bixmVNsdPS/UT2lch6iKZHg6OpsmczpCgijPBCJe+CgSaPiz+Rp6jGDAJySIsNS2YQV5N6EVqaXA==", "UyJAAVU8Ah/WIw==" });
        }
    }
}
