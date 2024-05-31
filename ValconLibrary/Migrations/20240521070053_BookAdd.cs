using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "yearOfBirth",
                table: "Authors",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(4,0)");

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    bookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    genre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    numberOfPages = table.Column<int>(type: "int", nullable: false),
                    publishingYear = table.Column<int>(type: "int", nullable: false),
                    totalCopies = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "date", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.bookId);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "authorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "SdYK7V/+x17OPWp5t/Idf5Q7QBU+w40R6wsWrRH6LOCNtPVwWoyF6wG/mJvax9/+pFRUbmMZnddVIxUr2XCQsB4Mx2urzbqTS7HStxeA0uwQFPZRK2ZYDBIqbgT1NUBS8/gDUhHWHwU2cTqJBIz27C24yvpSQQiTPNXqZisoL35LIwOeZtAHCa+K3HBLMr8qoH/mYTSYqrTC0PGrMXHb+UOCjy3FA9XBAtRuZm5wzpjdAFQQkOWxkPgBnaBi12oLrpV7Fi+Z394MgHtcyM6ShE93X85AaDya0RZzqIZjnuM78Yavhds3zqkQnmdeRfzcq23zGvmx1gxGiIGfGi0LoQ==", "SW3tQXT3Utl+2w==" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BookId",
                table: "AuthorBook",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.AlterColumn<decimal>(
                name: "yearOfBirth",
                table: "Authors",
                type: "numeric(4,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "mDJzDcObp/ZekIbdVNCcafluOj74O2odqUQb4gX8zNBNuZw+9tQKMFcN4W+ZJZMhMYtRVVQ+doigEf6EX+nk8lTfYUX20cTv56kgmw3LjywcXyxl2mX1gARdZhy+vXWtSRljFfDTcOgfcjIqHQLdfr04szfc82zsx8q/p6cb8PPH3mDvcA5Tv6MUodPnIeMihQJZu1bWeRSZxxGiPS6lEYMpqHpabdxDx+moQUCl38/taeYlGqBibYHrMMOw0ffDGWJ2x4flYv3H3VBzkgk1coDAW+29A+RIciYB13BlsNBBZoAp9SgdtNE+od3SnU5lLpOW1jnTYpEAXdCaDg47Dw==", "LtUmkkkMuS1wnQ==" });
        }
    }
}
