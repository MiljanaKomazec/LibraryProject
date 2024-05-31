using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modifiedAt",
                table: "Books",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Books",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "bookId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "HMwjhtjHVmErD0NhbImFNKKBN9UizDZpuisW7cnv1/iFxqI0I6y/4rQBPE4Jz5edNkmVek1COjLZJBTX0WAramBSYa2SQdurhLvil2BEF26n7ot33VdjnnfAaYJYJegsNbEssP6w4qw/yoWHVxy8h8pQRdnFR3XqTVoZXYrhiLCFyPT2SKk0MpZnfrP2oMR+5mvxY3E4eb00TvocRIA6x5mdgR4ip0JL9NCGVgavF2MW3fCs4eEz5BofyMTDlBule5GE/IZM2Yptd//SGBLvm/9LOu7TBLbCC3E+RbcsxpYQnicmXnSsxfXZ5nio4JtwxjePeNI+lnbDyUR8WruEOQ==", "G7ORS4t/NdlU+Q==" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Books_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "bookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBook_Books_BookId",
                table: "AuthorBook");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.AlterColumn<DateTime>(
                name: "modifiedAt",
                table: "Book",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdAt",
                table: "Book",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "bookId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "SdYK7V/+x17OPWp5t/Idf5Q7QBU+w40R6wsWrRH6LOCNtPVwWoyF6wG/mJvax9/+pFRUbmMZnddVIxUr2XCQsB4Mx2urzbqTS7HStxeA0uwQFPZRK2ZYDBIqbgT1NUBS8/gDUhHWHwU2cTqJBIz27C24yvpSQQiTPNXqZisoL35LIwOeZtAHCa+K3HBLMr8qoH/mYTSYqrTC0PGrMXHb+UOCjy3FA9XBAtRuZm5wzpjdAFQQkOWxkPgBnaBi12oLrpV7Fi+Z394MgHtcyM6ShE93X85AaDya0RZzqIZjnuM78Yavhds3zqkQnmdeRfzcq23zGvmx1gxGiIGfGi0LoQ==", "SW3tQXT3Utl+2w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBook_Book_BookId",
                table: "AuthorBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "bookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
