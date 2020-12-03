using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Sortiranje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdJagenjcka",
                table: "Jagenjcek",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdJagenjcka",
                table: "Jagenjcek",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
