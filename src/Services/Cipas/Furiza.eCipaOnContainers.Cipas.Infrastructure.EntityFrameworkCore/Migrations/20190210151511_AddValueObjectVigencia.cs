using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class AddValueObjectVigencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Vigencia_Inicio",
                table: "Cipas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Vigencia_Termino",
                table: "Cipas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vigencia_Inicio",
                table: "Cipas");

            migrationBuilder.DropColumn(
                name: "Vigencia_Termino",
                table: "Cipas");
        }
    }
}
