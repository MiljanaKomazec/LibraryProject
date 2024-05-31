using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookRentId",
                table: "BookRents",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "Books",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 60);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "ZfZl50VrspCtsXySvtKhVqp3piYyNHlyminwNcS9eAFAICWizxhG3VaLivGz2rh0hT6qOQhxXHUdgGHF7IdQTx5xP92EKc0WhIiNi8hXUsFFwAmvr55vvwrIXB/d6s7mY8lpqIjgapZ6qlzveZ3CI6wd4djd4mFLOlZC200/G034kW/YKQMmDvQhLq4UG/2bS/9p2pANVkFZPtD0yWeaflqh/ZrkrFTY/PUBhITPaXx1r4Whu8Uf7+WPXMkNoyvOeCM5rL/5oTPrmTsAg9AMUl0kNbjxHVeCsx8prTTbaD/JF8B+iW5J2OfSEUl0kC1KLQBPD2wZXFQ39Odf5U73SA==", "82CKLQpxgsj4QA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BookRents",
                newName: "BookRentId");

            migrationBuilder.AlterColumn<int>(
                name: "genre",
                table: "Books",
                type: "int",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "7e3G+zXkJIkItvTdiuNtQnHy+0/18rQ/EW6RTMUxu2/xKegbExFSuMFIVtbUeNxzArRw+I3OE8Q98KyY00xNKaUFwSAb+VXdM2q7tks0R/vHpeR5Mz7thJNIux5MFjfF2hbgzJq2ejgSpmgwRpKHXbgP22LNqpio+h9fhEA1a+1EEyfsSpAY2Vc2ilLGEfWqzRFWidcgY8xDOvFG53tjonPRsPudddIlGswKPqtZxQBRZe9m1bBl8RqP+qQ0EXzGfplcP8BkoKy0DZa4JoCAcDe5f9KLKIwDZ6pQ9S7yAVMpLPMmaMiRC4fHhvzgStNsPlJ7nZ0j7cZpEewJkTOsww==", "E5QsrXrKa2rbqA==" });
        }
    }
}
