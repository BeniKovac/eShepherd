using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crede",
                columns: table => new
                {
                    CredeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SteviloOvc = table.Column<int>(nullable: false),
                    Opombe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crede", x => x.CredeID);
                });

            migrationBuilder.CreateTable(
                name: "Ovca",
                columns: table => new
                {
                    OvcaID = table.Column<string>(nullable: false),
                    CredaIDCredeID = table.Column<int>(nullable: true),
                    DatumRojstva = table.Column<DateTime>(nullable: false),
                    Pasma = table.Column<string>(nullable: true),
                    IdMame = table.Column<string>(nullable: true),
                    IdOceta = table.Column<string>(nullable: true),
                    SteviloSorojencev = table.Column<int>(nullable: false),
                    Stanje = table.Column<string>(nullable: true),
                    Opombe = table.Column<string>(nullable: true),
                    SteviloKotitev = table.Column<int>(nullable: false),
                    PovprecjeJagenjckov = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ovca", x => x.OvcaID);
                    table.ForeignKey(
                        name: "FK_Ovca_Crede_CredaIDCredeID",
                        column: x => x.CredaIDCredeID,
                        principalTable: "Crede",
                        principalColumn: "CredeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oven",
                columns: table => new
                {
                    OvenID = table.Column<string>(nullable: false),
                    CredaIDCredeID = table.Column<int>(nullable: true),
                    DatumRojstva = table.Column<DateTime>(nullable: false),
                    Pasma = table.Column<string>(nullable: true),
                    IdMame = table.Column<string>(nullable: true),
                    IdOceta = table.Column<string>(nullable: true),
                    SteviloSorojencev = table.Column<int>(nullable: false),
                    Stanje = table.Column<string>(nullable: true),
                    Opombe = table.Column<string>(nullable: true),
                    Poreklo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oven", x => x.OvenID);
                    table.ForeignKey(
                        name: "FK_Oven_Crede_CredaIDCredeID",
                        column: x => x.CredaIDCredeID,
                        principalTable: "Crede",
                        principalColumn: "CredeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gonitev",
                columns: table => new
                {
                    GonitevID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumGonitve = table.Column<DateTime>(nullable: false),
                    OvenID = table.Column<string>(nullable: true),
                    OvcaID = table.Column<string>(nullable: true),
                    PredvidenaKotitev = table.Column<DateTime>(nullable: false),
                    Opombe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gonitev", x => x.GonitevID);
                    table.ForeignKey(
                        name: "FK_Gonitev_Ovca_OvcaID",
                        column: x => x.OvcaID,
                        principalTable: "Ovca",
                        principalColumn: "OvcaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gonitev_Oven_OvenID",
                        column: x => x.OvenID,
                        principalTable: "Oven",
                        principalColumn: "OvenID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kotitev",
                columns: table => new
                {
                    KotitevID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumKotitve = table.Column<DateTime>(nullable: false),
                    SteviloMladih = table.Column<int>(nullable: false),
                    OvenID = table.Column<string>(nullable: true),
                    OvcaID = table.Column<string>(nullable: true),
                    SteviloMrtvih = table.Column<int>(nullable: false),
                    Opombe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kotitev", x => x.KotitevID);
                    table.ForeignKey(
                        name: "FK_Kotitev_Ovca_OvcaID",
                        column: x => x.OvcaID,
                        principalTable: "Ovca",
                        principalColumn: "OvcaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kotitev_Oven_OvenID",
                        column: x => x.OvenID,
                        principalTable: "Oven",
                        principalColumn: "OvenID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jagenjcek",
                columns: table => new
                {
                    IdJagenjcka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKotitveKotitevID = table.Column<int>(nullable: true),
                    spol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jagenjcek", x => x.IdJagenjcka);
                    table.ForeignKey(
                        name: "FK_Jagenjcek_Kotitev_IdKotitveKotitevID",
                        column: x => x.IdKotitveKotitevID,
                        principalTable: "Kotitev",
                        principalColumn: "KotitevID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gonitev_OvcaID",
                table: "Gonitev",
                column: "OvcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Gonitev_OvenID",
                table: "Gonitev",
                column: "OvenID");

            migrationBuilder.CreateIndex(
                name: "IX_Jagenjcek_IdKotitveKotitevID",
                table: "Jagenjcek",
                column: "IdKotitveKotitevID");

            migrationBuilder.CreateIndex(
                name: "IX_Kotitev_OvcaID",
                table: "Kotitev",
                column: "OvcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kotitev_OvenID",
                table: "Kotitev",
                column: "OvenID");

            migrationBuilder.CreateIndex(
                name: "IX_Ovca_CredaIDCredeID",
                table: "Ovca",
                column: "CredaIDCredeID");

            migrationBuilder.CreateIndex(
                name: "IX_Oven_CredaIDCredeID",
                table: "Oven",
                column: "CredaIDCredeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gonitev");

            migrationBuilder.DropTable(
                name: "Jagenjcek");

            migrationBuilder.DropTable(
                name: "Kotitev");

            migrationBuilder.DropTable(
                name: "Ovca");

            migrationBuilder.DropTable(
                name: "Oven");

            migrationBuilder.DropTable(
                name: "Crede");
        }
    }
}
