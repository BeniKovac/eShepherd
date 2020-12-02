using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class ovcaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oven_Ovca_OvcaID",
                table: "Oven");

            migrationBuilder.DropIndex(
                name: "IX_Oven_OvcaID",
                table: "Oven");

            migrationBuilder.DropColumn(
                name: "OvcaID",
                table: "Oven");

            migrationBuilder.DropColumn(
                name: "IdMame",
                table: "Ovca");

            migrationBuilder.DropColumn(
                name: "IdOceta",
                table: "Ovca");

            migrationBuilder.AddColumn<string>(
                name: "mamaID",
                table: "Oven",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "oceID",
                table: "Oven",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "oceID",
                table: "Ovca",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ovca_oceID",
                table: "Ovca",
                column: "oceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ovca_Oven_oceID",
                table: "Ovca",
                column: "oceID",
                principalTable: "Oven",
                principalColumn: "OvenID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ovca_Oven_oceID",
                table: "Ovca");

            migrationBuilder.DropIndex(
                name: "IX_Ovca_oceID",
                table: "Ovca");

            migrationBuilder.DropColumn(
                name: "mamaID",
                table: "Oven");

            migrationBuilder.DropColumn(
                name: "oceID",
                table: "Oven");

            migrationBuilder.DropColumn(
                name: "oceID",
                table: "Ovca");

            migrationBuilder.AddColumn<string>(
                name: "OvcaID",
                table: "Oven",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdMame",
                table: "Ovca",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdOceta",
                table: "Ovca",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oven_OvcaID",
                table: "Oven",
                column: "OvcaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Oven_Ovca_OvcaID",
                table: "Oven",
                column: "OvcaID",
                principalTable: "Ovca",
                principalColumn: "OvcaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
