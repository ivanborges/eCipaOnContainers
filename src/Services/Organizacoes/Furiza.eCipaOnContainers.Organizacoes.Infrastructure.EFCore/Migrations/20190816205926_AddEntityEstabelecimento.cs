using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Organizacoes.Infrastructure.EFCore.Migrations
{
    public partial class AddEntityEstabelecimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_Codigo",
                table: "Estabelecimentos",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimentos");
        }
    }
}
