using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class jagenjcki3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SteviloMladih",
                table: "Kotitev",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SteviloMladih",
                table: "Kotitev");
        }
    }
}
