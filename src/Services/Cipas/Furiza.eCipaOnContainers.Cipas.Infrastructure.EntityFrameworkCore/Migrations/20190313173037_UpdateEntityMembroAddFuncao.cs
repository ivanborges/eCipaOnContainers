using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateEntityMembroAddFuncao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Funcao",
                table: "Membros",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Membros");
        }
    }
}
