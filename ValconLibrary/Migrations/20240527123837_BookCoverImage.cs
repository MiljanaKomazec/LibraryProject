using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValconLibrary.Migrations
{
    /// <inheritdoc />
    public partial class BookCoverImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "coverImage",
                table: "Books",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "CtUrfXVUKpyQqcWSfVk1iV/v8rFaD1sZvtWj922myWNDlLPWqICzKEzBeJA7q+NP0pE4ZIG4JPlt3c9RzG/KziGtTkKRCurqBAi4JtlXX6DdVaOFNAOsOryToNyvHq+jlkMcz23+bu0JZUYEekvvn1X4ewO1TYVOIZywCgskxy3Cw9141k7zjzJ9CJF+Fh3DRROpHqqDNIHdutwS+dYB1dCZUYaDKiUsnnT5+9zqRXQE5zodOR9gVbAjzb08/IsdPFeicouB+pj83CfKO93ugXV0R4iiJtEwf7kFIb176TzjuqiNOzYYLD26ZgAYwdsE2nDd52UU6+O2yTB1TrznsQ==", "A37vlwgw/UkIqQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coverImage",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                columns: new[] { "password", "salt" },
                values: new object[] { "ZfZl50VrspCtsXySvtKhVqp3piYyNHlyminwNcS9eAFAICWizxhG3VaLivGz2rh0hT6qOQhxXHUdgGHF7IdQTx5xP92EKc0WhIiNi8hXUsFFwAmvr55vvwrIXB/d6s7mY8lpqIjgapZ6qlzveZ3CI6wd4djd4mFLOlZC200/G034kW/YKQMmDvQhLq4UG/2bS/9p2pANVkFZPtD0yWeaflqh/ZrkrFTY/PUBhITPaXx1r4Whu8Uf7+WPXMkNoyvOeCM5rL/5oTPrmTsAg9AMUl0kNbjxHVeCsx8prTTbaD/JF8B+iW5J2OfSEUl0kC1KLQBPD2wZXFQ39Odf5U73SA==", "82CKLQpxgsj4QA==" });
        }
    }
}
