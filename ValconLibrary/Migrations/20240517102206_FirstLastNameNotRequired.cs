using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class FirstLastNameNotRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "jB6d+fUEs8n2foX6Y9s5bL9AIDFMhQyCCpAUIRlMLMtJQ6DAWrTb2fEz5vPZNwXh49Ed0/Cr/H1MZgMQg4qAELwR+NZiaZMdk6l2ZBFaJGFZh6lvZdbGMrgcWOWeJvu85nXL7MqbMt+twGHGNWAExVh1h03VJ4DskJ7Rg1V10ubcNDp1tAE9oeqM7AqzCfvJo5W5u55dSIloGy26Rg+o2a3aTVE7COPId/ILrgF3s7xgCkeuF+Zp49AAuGqW5GduMDq0mr8BYReETyUVZUR+nplXvz4yI4cl1YGXUnH/kqAJCWtzrysZn5qA+8XO4nz3TmyDTRecutQtCzAQBPBjyA==", "KAGi+3WWvAdqZQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
