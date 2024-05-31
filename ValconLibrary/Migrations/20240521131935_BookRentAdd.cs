using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookRentAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRents",
                columns: table => new
                {
                    BookRentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRents", x => x.BookRentId);
                    table.ForeignKey(
                        name: "FK_BookRents_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "bookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "2OJf+YaCyIzhGrsxrmStga+2YXzSW5GjpiheXXjgKhjgcopdoZWePPy1AINqd+rI4dmiGcg6f2Kjwrl/i+pKeFrgpqhzQyLohEhKNhwqstu6U6Wg3ELYmpyrPLFfarNk35k94g5Sxqz/u+4rCkLGnIpHSRxAWCZ0/771nGzwD5Oph0b6Uqg+d4l5cuZrYi+Z6eurNpOXAWkmbuauo3ZRLXr7D85EY844f2JoGwmq/EryqCTNHh5oLzxPbUJjHIcbnPtAe8V7q5bhXKfNZI9nCoE5ijfY//1/U2XOf9csLlWr9KI69ZltDsC9TN81bMsZe8dXjr6Wr8U6yinY3tZtmQ==", "gMEBxVzFaXaf9w==" });

            migrationBuilder.CreateIndex(
                name: "IX_BookRents_BookId",
                table: "BookRents",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRents_UserId",
                table: "BookRents",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "HMwjhtjHVmErD0NhbImFNKKBN9UizDZpuisW7cnv1/iFxqI0I6y/4rQBPE4Jz5edNkmVek1COjLZJBTX0WAramBSYa2SQdurhLvil2BEF26n7ot33VdjnnfAaYJYJegsNbEssP6w4qw/yoWHVxy8h8pQRdnFR3XqTVoZXYrhiLCFyPT2SKk0MpZnfrP2oMR+5mvxY3E4eb00TvocRIA6x5mdgR4ip0JL9NCGVgavF2MW3fCs4eEz5BofyMTDlBule5GE/IZM2Yptd//SGBLvm/9LOu7TBLbCC3E+RbcsxpYQnicmXnSsxfXZ5nio4JtwxjePeNI+lnbDyUR8WruEOQ==", "G7ORS4t/NdlU+Q==" });
        }
    }
}
