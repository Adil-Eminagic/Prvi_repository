using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class skracenicadrzava : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "skracenica",
                table: "Drzava",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "skracenica",
                table: "Drzava");
        }
    }
}
