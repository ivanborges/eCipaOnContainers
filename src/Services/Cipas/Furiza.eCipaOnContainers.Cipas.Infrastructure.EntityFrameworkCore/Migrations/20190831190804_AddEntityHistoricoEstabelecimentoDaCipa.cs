using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class AddEntityHistoricoEstabelecimentoDaCipa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoEstabelecimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    EstabelecimentoId = table.Column<Guid>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    CipaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoEstabelecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoEstabelecimentos_Cipas_CipaId",
                        column: x => x.CipaId,
                        principalTable: "Cipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstabelecimentos_CipaId",
                table: "HistoricoEstabelecimentos",
                column: "CipaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoEstabelecimentos_EstabelecimentoId",
                table: "HistoricoEstabelecimentos",
                column: "EstabelecimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoEstabelecimentos");
        }
    }
}
