using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateEntityCipaChangeFornecedorToEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fornecedor",
                table: "Cipas");

            migrationBuilder.AddColumn<int>(
                name: "CodigoEmpresa",
                table: "Cipas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoEmpresa",
                table: "Cipas");

            migrationBuilder.AddColumn<int>(
                name: "Fornecedor",
                table: "Cipas",
                nullable: true);
        }
    }
}
