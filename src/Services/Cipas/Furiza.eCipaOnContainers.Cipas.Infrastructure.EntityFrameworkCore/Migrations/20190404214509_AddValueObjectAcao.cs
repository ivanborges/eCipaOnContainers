using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class AddValueObjectAcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aprovacao_Ator",
                table: "Atas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Aprovacao_Data",
                table: "Atas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Finalizacao_Ator",
                table: "Atas",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Finalizacao_Data",
                table: "Atas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aprovacao_Ator",
                table: "Atas");

            migrationBuilder.DropColumn(
                name: "Aprovacao_Data",
                table: "Atas");

            migrationBuilder.DropColumn(
                name: "Finalizacao_Ator",
                table: "Atas");

            migrationBuilder.DropColumn(
                name: "Finalizacao_Data",
                table: "Atas");
        }
    }
}
