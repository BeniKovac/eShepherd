using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class jagenjcek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SteviloMladih",
                table: "Kotitev");

            migrationBuilder.AlterColumn<int>(
                name: "SteviloMrtvih",
                table: "Kotitev",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SteviloMrtvih",
                table: "Kotitev",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SteviloMladih",
                table: "Kotitev",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
