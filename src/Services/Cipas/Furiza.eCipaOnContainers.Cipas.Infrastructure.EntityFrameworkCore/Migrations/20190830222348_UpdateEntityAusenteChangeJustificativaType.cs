using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateEntityAusenteChangeJustificativaType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Justificativa",
                table: "Ausentes",
                nullable: false,
                defaultValue: 99,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Justificativa",
                table: "Ausentes",
                nullable: true,
                oldClrType: typeof(int),
                oldDefaultValue: 99);
        }
    }
}
