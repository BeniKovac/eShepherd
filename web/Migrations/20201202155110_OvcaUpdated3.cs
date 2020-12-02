using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class OvcaUpdated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ovca_Ovca_OvcaID1",
                table: "Ovca");

            migrationBuilder.DropIndex(
                name: "IX_Ovca_OvcaID1",
                table: "Ovca");

            migrationBuilder.DropColumn(
                name: "OvcaID1",
                table: "Ovca");

            migrationBuilder.AddColumn<string>(
                name: "mamaID",
                table: "Ovca",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ovca_mamaID",
                table: "Ovca",
                column: "mamaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ovca_Ovca_mamaID",
                table: "Ovca",
                column: "mamaID",
                principalTable: "Ovca",
                principalColumn: "OvcaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ovca_Ovca_mamaID",
                table: "Ovca");

            migrationBuilder.DropIndex(
                name: "IX_Ovca_mamaID",
                table: "Ovca");

            migrationBuilder.DropColumn(
                name: "mamaID",
                table: "Ovca");

            migrationBuilder.AddColumn<string>(
                name: "OvcaID1",
                table: "Ovca",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ovca_OvcaID1",
                table: "Ovca",
                column: "OvcaID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ovca_Ovca_OvcaID1",
                table: "Ovca",
                column: "OvcaID1",
                principalTable: "Ovca",
                principalColumn: "OvcaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
