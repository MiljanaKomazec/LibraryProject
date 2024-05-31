using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookRentRentalPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalPeriodInDays",
                table: "BookRents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "A4fqqmiyR+Wg14mla/M3ZJGQtBgJqDR1rXUnHkSEIXVNjXCWf5YKXnWVhQRmjEoTVJwxy74RTN6oF8FKoAh0uKilaD9I0O1TMvtMc2ylpGSdEArI44o6XbZSftF46OZsDlT4ExBDtVb6UH/0A32ii83mB3qREGiYhSADqvnGzKXEN7kWQ4PJJ3TNlBbsuErIJ7Ww3ilcBwvN6/+/QVKWenY9CQLzHmxdNPuqq86/wCdfynkefSUmBAjoPe5y7z4YOdk6DFGEvCTvGIP3936o1QEa1QZpmEQ12uKGLDTRldV33cjkldRRgpBUckex6fLK5CqwkVJckwVC4faZ4Ok0Hg==", "WC0vyVfzZH21LQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalPeriodInDays",
                table: "BookRents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "CtUrfXVUKpyQqcWSfVk1iV/v8rFaD1sZvtWj922myWNDlLPWqICzKEzBeJA7q+NP0pE4ZIG4JPlt3c9RzG/KziGtTkKRCurqBAi4JtlXX6DdVaOFNAOsOryToNyvHq+jlkMcz23+bu0JZUYEekvvn1X4ewO1TYVOIZywCgskxy3Cw9141k7zjzJ9CJF+Fh3DRROpHqqDNIHdutwS+dYB1dCZUYaDKiUsnnT5+9zqRXQE5zodOR9gVbAjzb08/IsdPFeicouB+pj83CfKO93ugXV0R4iiJtEwf7kFIb176TzjuqiNOzYYLD26ZgAYwdsE2nDd52UU6+O2yTB1TrznsQ==", "A37vlwgw/UkIqQ==" });
        }
    }
}
