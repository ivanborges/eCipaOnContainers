using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class RemoveEntitiesEstabelecimentoPlanoDeAcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reunioes_PlanosDeAcao_PlanoDeAcaoId",
                table: "Reunioes");

            migrationBuilder.DropTable(
                name: "CipasAnteriores");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "PlanosDeAcao");

            migrationBuilder.DropIndex(
                name: "IX_Reunioes_PlanoDeAcaoId",
                table: "Reunioes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CipaId = table.Column<Guid>(nullable: true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estabelecimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estabelecimentos_Cipas_CipaId",
                        column: x => x.CipaId,
                        principalTable: "Cipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanosDeAcao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosDeAcao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CipasAnteriores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CipaId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Acao = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    DataRealizacao = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    PlanoDeAcaoId = table.Column<Guid>(nullable: false),
                    Prazo = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_PlanosDeAcao_PlanoDeAcaoId",
                        column: x => x.PlanoDeAcaoId,
                        principalTable: "PlanosDeAcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    ItemId = table.Column<Guid>(nullable: false),
                    NomeCompleto = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsaveis_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reunioes_PlanoDeAcaoId",
                table: "Reunioes",
                column: "PlanoDeAcaoId",
                unique: true,
                filter: "[PlanoDeAcaoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CipasAnteriores_CipaId",
                table: "CipasAnteriores",
                column: "CipaId");

            migrationBuilder.CreateIndex(
                name: "IX_CipasAnteriores_EstabelecimentoId",
                table: "CipasAnteriores",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_CipaId",
                table: "Estabelecimentos",
                column: "CipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estabelecimentos_Codigo",
                table: "Estabelecimentos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Codigo",
                table: "Itens",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_PlanoDeAcaoId",
                table: "Itens",
                column: "PlanoDeAcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosDeAcao_Ano",
                table: "PlanosDeAcao",
                column: "Ano");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosDeAcao_Codigo",
                table: "PlanosDeAcao",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_ItemId",
                table: "Responsaveis",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reunioes_PlanosDeAcao_PlanoDeAcaoId",
                table: "Reunioes",
                column: "PlanoDeAcaoId",
                principalTable: "PlanosDeAcao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
