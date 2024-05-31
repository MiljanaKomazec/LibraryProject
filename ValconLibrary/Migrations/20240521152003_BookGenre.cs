using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "genre",
                table: "Books",
                type: "int",
                maxLength: 60,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "7e3G+zXkJIkItvTdiuNtQnHy+0/18rQ/EW6RTMUxu2/xKegbExFSuMFIVtbUeNxzArRw+I3OE8Q98KyY00xNKaUFwSAb+VXdM2q7tks0R/vHpeR5Mz7thJNIux5MFjfF2hbgzJq2ejgSpmgwRpKHXbgP22LNqpio+h9fhEA1a+1EEyfsSpAY2Vc2ilLGEfWqzRFWidcgY8xDOvFG53tjonPRsPudddIlGswKPqtZxQBRZe9m1bBl8RqP+qQ0EXzGfplcP8BkoKy0DZa4JoCAcDe5f9KLKIwDZ6pQ9S7yAVMpLPMmaMiRC4fHhvzgStNsPlJ7nZ0j7cZpEewJkTOsww==", "E5QsrXrKa2rbqA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "genre",
                table: "Books",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 60);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "2OJf+YaCyIzhGrsxrmStga+2YXzSW5GjpiheXXjgKhjgcopdoZWePPy1AINqd+rI4dmiGcg6f2Kjwrl/i+pKeFrgpqhzQyLohEhKNhwqstu6U6Wg3ELYmpyrPLFfarNk35k94g5Sxqz/u+4rCkLGnIpHSRxAWCZ0/771nGzwD5Oph0b6Uqg+d4l5cuZrYi+Z6eurNpOXAWkmbuauo3ZRLXr7D85EY844f2JoGwmq/EryqCTNHh5oLzxPbUJjHIcbnPtAe8V7q5bhXKfNZI9nCoE5ijfY//1/U2XOf9csLlWr9KI69ZltDsC9TN81bMsZe8dXjr6Wr8U6yinY3tZtmQ==", "gMEBxVzFaXaf9w==" });
        }
    }
}
