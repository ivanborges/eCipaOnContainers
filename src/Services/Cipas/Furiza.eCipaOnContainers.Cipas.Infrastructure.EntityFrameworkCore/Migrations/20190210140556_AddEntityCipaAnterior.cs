using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class AddEntityCipaAnterior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CipasAnteriores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    CipaId = table.Column<Guid>(nullable: false),
                    EstabelecimentoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CipasAnteriores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CipasAnteriores_Cipas_CipaId",
                        column: x => x.CipaId,
                        principalTable: "Cipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CipasAnteriores_Estabelecimentos_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CipasAnteriores_CipaId",
                table: "CipasAnteriores",
                column: "CipaId");

            migrationBuilder.CreateIndex(
                name: "IX_CipasAnteriores_EstabelecimentoId",
                table: "CipasAnteriores",
                column: "EstabelecimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CipasAnteriores");
        }
    }
}
