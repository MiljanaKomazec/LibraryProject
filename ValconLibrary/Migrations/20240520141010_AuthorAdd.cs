using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AuthorAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    authorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    yearOfBirth = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "date", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.authorId);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "7LU03mmojijLVpbEjg33582G195H2Ar/RW0LXKuu3iPMBg4su+5n2jAPKOKUrCmkbz6MxoeQN5ROpUd0hgMtmPj+s33urhw/9vT+JBFG9UDPnokavYlT7KvQEziQ6leiULukQUACjlDGdcMX//PegfqrDsKqurbQD508B0WV+hig97K3WUJ6l6iJts3vLnQGeY8ujyt8i0vIPz4xMJ2tO4FZhg2qdHXt0UbJpToCqBnnPU7h6HJh2cyyIAY7+uBFYGSX/Pvvu0AlW/VAL1WkGDG3pf7yN+oxDN9yTz6cbKH8oCK4/brA4OSt2A/lDflQak8aBcGGU/REYXbsjhhq0w==", "DYVwLVgw3ElNzg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "jB6d+fUEs8n2foX6Y9s5bL9AIDFMhQyCCpAUIRlMLMtJQ6DAWrTb2fEz5vPZNwXh49Ed0/Cr/H1MZgMQg4qAELwR+NZiaZMdk6l2ZBFaJGFZh6lvZdbGMrgcWOWeJvu85nXL7MqbMt+twGHGNWAExVh1h03VJ4DskJ7Rg1V10ubcNDp1tAE9oeqM7AqzCfvJo5W5u55dSIloGy26Rg+o2a3aTVE7COPId/ILrgF3s7xgCkeuF+Zp49AAuGqW5GduMDq0mr8BYReETyUVZUR+nplXvz4yI4cl1YGXUnH/kqAJCWtzrysZn5qA+8XO4nz3TmyDTRecutQtCzAQBPBjyA==", "KAGi+3WWvAdqZQ==" });
        }
    }
}
