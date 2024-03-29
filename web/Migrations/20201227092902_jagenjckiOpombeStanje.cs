﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class jagenjckiOpombeStanje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "opombe",
                table: "Jagenjcek",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "stanje",
                table: "Jagenjcek",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "opombe",
                table: "Jagenjcek");

            migrationBuilder.DropColumn(
                name: "stanje",
                table: "Jagenjcek");
        }
    }
}
