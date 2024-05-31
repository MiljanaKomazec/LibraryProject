using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AuthorYB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "mDJzDcObp/ZekIbdVNCcafluOj74O2odqUQb4gX8zNBNuZw+9tQKMFcN4W+ZJZMhMYtRVVQ+doigEf6EX+nk8lTfYUX20cTv56kgmw3LjywcXyxl2mX1gARdZhy+vXWtSRljFfDTcOgfcjIqHQLdfr04szfc82zsx8q/p6cb8PPH3mDvcA5Tv6MUodPnIeMihQJZu1bWeRSZxxGiPS6lEYMpqHpabdxDx+moQUCl38/taeYlGqBibYHrMMOw0ffDGWJ2x4flYv3H3VBzkgk1coDAW+29A+RIciYB13BlsNBBZoAp9SgdtNE+od3SnU5lLpOW1jnTYpEAXdCaDg47Dw==", "LtUmkkkMuS1wnQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "7LU03mmojijLVpbEjg33582G195H2Ar/RW0LXKuu3iPMBg4su+5n2jAPKOKUrCmkbz6MxoeQN5ROpUd0hgMtmPj+s33urhw/9vT+JBFG9UDPnokavYlT7KvQEziQ6leiULukQUACjlDGdcMX//PegfqrDsKqurbQD508B0WV+hig97K3WUJ6l6iJts3vLnQGeY8ujyt8i0vIPz4xMJ2tO4FZhg2qdHXt0UbJpToCqBnnPU7h6HJh2cyyIAY7+uBFYGSX/Pvvu0AlW/VAL1WkGDG3pf7yN+oxDN9yTz6cbKH8oCK4/brA4OSt2A/lDflQak8aBcGGU/REYXbsjhhq0w==", "DYVwLVgw3ElNzg==" });
        }
    }
}
