using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class UpdateAggregateReuniao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consent",
                table: "Participantes");

            migrationBuilder.RenameColumn(
                name: "Vigencia_Termino",
                table: "Cipas",
                newName: "Mandato_Termino");

            migrationBuilder.RenameColumn(
                name: "Vigencia_Inicio",
                table: "Cipas",
                newName: "Mandato_Inicio");

            migrationBuilder.AddColumn<int>(
                name: "MesDeReferencia",
                table: "Reunioes",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Participantes",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EConvidado",
                table: "Participantes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "Participantes",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organizacao",
                table: "Participantes",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PossuiConsentValido",
                table: "Participantes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Local",
                table: "Atas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Assuntos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    ClassificacaoDaInformacao = table.Column<int>(nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Keywords = table.Column<string>(maxLength: 200, nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    AtaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assuntos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assuntos_Atas_AtaId",
                        column: x => x.AtaId,
                        principalTable: "Atas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ausentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    NomeCompleto = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    PossuiConsentValido = table.Column<bool>(nullable: false, defaultValue: false),
                    AtaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ausentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ausentes_Atas_AtaId",
                        column: x => x.AtaId,
                        principalTable: "Atas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsentsDeParticipantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Value = table.Column<bool>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    ParticipanteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsentsDeParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsentsDeParticipantes_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alteracoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(nullable: false),
                    Versao = table.Column<int>(nullable: false),
                    AssuntoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alteracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alteracoes_Assuntos_AssuntoId",
                        column: x => x.AssuntoId,
                        principalTable: "Assuntos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsentsDeAusentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Value = table.Column<bool>(nullable: false),
                    Justificativa = table.Column<string>(nullable: true),
                    AusenteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsentsDeAusentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsentsDeAusentes_Ausentes_AusenteId",
                        column: x => x.AusenteId,
                        principalTable: "Ausentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alteracoes_AssuntoId",
                table: "Alteracoes",
                column: "AssuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_Assuntos_AtaId",
                table: "Assuntos",
                column: "AtaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ausentes_AtaId",
                table: "Ausentes",
                column: "AtaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsentsDeAusentes_AusenteId",
                table: "ConsentsDeAusentes",
                column: "AusenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsentsDeParticipantes_ParticipanteId",
                table: "ConsentsDeParticipantes",
                column: "ParticipanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alteracoes");

            migrationBuilder.DropTable(
                name: "ConsentsDeAusentes");

            migrationBuilder.DropTable(
                name: "ConsentsDeParticipantes");

            migrationBuilder.DropTable(
                name: "Assuntos");

            migrationBuilder.DropTable(
                name: "Ausentes");

            migrationBuilder.DropColumn(
                name: "MesDeReferencia",
                table: "Reunioes");

            migrationBuilder.DropColumn(
                name: "EConvidado",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "Organizacao",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "PossuiConsentValido",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "Local",
                table: "Atas");

            migrationBuilder.RenameColumn(
                name: "Mandato_Termino",
                table: "Cipas",
                newName: "Vigencia_Termino");

            migrationBuilder.RenameColumn(
                name: "Mandato_Inicio",
                table: "Cipas",
                newName: "Vigencia_Inicio");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Participantes",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "Consent",
                table: "Participantes",
                nullable: true);
        }
    }
}
