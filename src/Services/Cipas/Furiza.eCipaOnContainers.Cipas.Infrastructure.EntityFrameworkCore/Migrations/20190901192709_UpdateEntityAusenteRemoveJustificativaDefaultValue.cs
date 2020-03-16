using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateEntityAusenteRemoveJustificativaDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Justificativa",
                table: "Ausentes",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 99);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Justificativa",
                table: "Ausentes",
                nullable: false,
                defaultValue: 99,
                oldClrType: typeof(int));
        }
    }
}
