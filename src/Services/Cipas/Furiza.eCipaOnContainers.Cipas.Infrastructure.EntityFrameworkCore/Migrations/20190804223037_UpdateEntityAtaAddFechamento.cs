using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateEntityAtaAddFechamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fechamento_Ator",
                table: "Atas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fechamento_Data",
                table: "Atas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fechamento_Ator",
                table: "Atas");

            migrationBuilder.DropColumn(
                name: "Fechamento_Data",
                table: "Atas");
        }
    }
}
