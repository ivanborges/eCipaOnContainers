using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateEntityItemAddNumero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Itens",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Itens");
        }
    }
}
