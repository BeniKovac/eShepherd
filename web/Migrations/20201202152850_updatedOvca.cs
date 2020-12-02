using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class updatedOvca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdMame",
                table: "Ovca",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OvcaID1",
                table: "Ovca",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "IdMame",
                table: "Ovca",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
