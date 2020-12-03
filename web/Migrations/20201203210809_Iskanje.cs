using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Iskanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jagenjcek_Kotitev_KotitevID",
                table: "Jagenjcek");

            migrationBuilder.DropIndex(
                name: "IX_Jagenjcek_KotitevID",
                table: "Jagenjcek");

            migrationBuilder.AlterColumn<string>(
                name: "KotitevID",
                table: "Jagenjcek",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "KotitevID1",
                table: "Jagenjcek",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jagenjcek_KotitevID1",
                table: "Jagenjcek",
                column: "KotitevID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Jagenjcek_Kotitev_KotitevID1",
                table: "Jagenjcek",
                column: "KotitevID1",
                principalTable: "Kotitev",
                principalColumn: "KotitevID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jagenjcek_Kotitev_KotitevID1",
                table: "Jagenjcek");

            migrationBuilder.DropIndex(
                name: "IX_Jagenjcek_KotitevID1",
                table: "Jagenjcek");

            migrationBuilder.DropColumn(
                name: "KotitevID1",
                table: "Jagenjcek");

            migrationBuilder.AlterColumn<int>(
                name: "KotitevID",
                table: "Jagenjcek",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jagenjcek_KotitevID",
                table: "Jagenjcek",
                column: "KotitevID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jagenjcek_Kotitev_KotitevID",
                table: "Jagenjcek",
                column: "KotitevID",
                principalTable: "Kotitev",
                principalColumn: "KotitevID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
