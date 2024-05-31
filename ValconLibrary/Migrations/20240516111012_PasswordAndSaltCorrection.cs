using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class PasswordAndSaltCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "P+03CZXQwPidLMjuoV7B26iBaL0PlwlfdHZz3cP4WTZuoAjZbe5MqJCtruLZnq0rQkxJ0eu/EaQq2FLQqEgdkdGXXrL6xwtnsH3bgMVvwaxMtAVyz1/hircUxg2xNgOi4CukRhUW/94BKkdVpXqbQHyue0cwWKd5jHY3Lv8xBqh0GxvFdMWYwHz28JS6Japbpm3nw0R/bFp96AKMCHDdSWrzhS/FLMvorMOgjPMjpxvPrsRXC8YacL6r469uxXWBwPhig1bgS5bixmVNsdPS/UT2lch6iKZHg6OpsmczpCgijPBCJe+CgSaPiz+Rp6jGDAJySIsNS2YQV5N6EVqaXA==", "UyJAAVU8Ah/WIw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "ZoG05mNx76EFRSOm9MeWuYFGOOZVo25EjQltikW5epDnkOwPRAY2fSxWrOhZGI0FJYSAgZNQe+LVHkQHKap4r8ADTDFpyxc9GaeKVHnMjz2tCheZ4PcyXsqdsILiiDbxsD/OFVtQxxQxEgOqUVNfZ07/zfd3/v6cVQ60H880UdLW+AhWtQ5WidhawvOD4tMRzl4j3V3n9DctzsSC0VtR6Ii+jLCsAPOejgcWSCYohOFjLhoAgA0iUHjMGgIrwyYNHGvHUnk1Mhtq0dvA4WVzjeX5BTM/xIpALgHtu+YLFGiEfwzQfBozgZpRyzCbc4WUcVcl1IIy1z2R54XSxWpCcg==", "HREjDgrlaXzC+A==" });
        }
    }
}
