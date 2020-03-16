using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class EntitiesCipaPlanoDeAcaoReuniao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Cipas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Cipas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlanosDeAcao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosDeAcao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Acao = table.Column<string>(nullable: true),
                    Prazo = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    DataRealizacao = table.Column<DateTime>(nullable: true),
                    PlanoDeAcaoId = table.Column<Guid>(nullable: false)
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
                name: "Reunioes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    CipaId = table.Column<Guid>(nullable: false),
                    DataPrevista = table.Column<DateTime>(nullable: false),
                    Local = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Extraordinaria = table.Column<bool>(nullable: false),
                    PlanoDeAcaoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reunioes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reunioes_Cipas_CipaId",
                        column: x => x.CipaId,
                        principalTable: "Cipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reunioes_PlanosDeAcao_PlanoDeAcaoId",
                        column: x => x.PlanoDeAcaoId,
                        principalTable: "PlanosDeAcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    NomeCompleto = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    ItemId = table.Column<Guid>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Atas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    CodigoCipa = table.Column<string>(maxLength: 100, nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: true),
                    Termino = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ReuniaoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atas_Reunioes_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalTable: "Reunioes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    NomeCompleto = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Consent = table.Column<bool>(nullable: true),
                    AtaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participantes_Atas_AtaId",
                        column: x => x.AtaId,
                        principalTable: "Atas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cipas_Ano",
                table: "Cipas",
                column: "Ano");

            migrationBuilder.CreateIndex(
                name: "IX_Atas_Codigo",
                table: "Atas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atas_CodigoCipa",
                table: "Atas",
                column: "CodigoCipa");

            migrationBuilder.CreateIndex(
                name: "IX_Atas_ReuniaoId",
                table: "Atas",
                column: "ReuniaoId",
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
                name: "IX_Participantes_AtaId",
                table: "Participantes",
                column: "AtaId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Reunioes_CipaId",
                table: "Reunioes",
                column: "CipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reunioes_PlanoDeAcaoId",
                table: "Reunioes",
                column: "PlanoDeAcaoId",
                unique: true,
                filter: "[PlanoDeAcaoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Atas");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Reunioes");

            migrationBuilder.DropTable(
                name: "PlanosDeAcao");

            migrationBuilder.DropIndex(
                name: "IX_Cipas_Ano",
                table: "Cipas");

            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Cipas");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Cipas");
        }
    }
}
