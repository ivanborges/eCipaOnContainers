using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateEntityMembroRemoveIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Membros_UserName",
                table: "Membros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Membros_UserName",
                table: "Membros",
                column: "UserName",
                unique: true);
        }
    }
}
