using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateEntityCipaRemoveNomeDescricao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Cipas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Cipas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Cipas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Cipas",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
