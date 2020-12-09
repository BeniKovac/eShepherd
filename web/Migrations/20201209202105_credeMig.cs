using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class credeMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PovprecjeJagenjckov",
                table: "Ovca");

            migrationBuilder.DropColumn(
                name: "SteviloKotitev",
                table: "Ovca");

            migrationBuilder.DropColumn(
                name: "SteviloOvc",
                table: "Crede");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PovprecjeJagenjckov",
                table: "Ovca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SteviloKotitev",
                table: "Ovca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SteviloOvc",
                table: "Crede",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
