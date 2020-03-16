using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Furiza.eCipaOnContainers.Cipas.Infrastructure.EntityFrameworkCore.Migrations
{
    public partial class BaseEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cipas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cipas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estabelecimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    Codigo = table.Column<string>(maxLength: 100, nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    CipaId = table.Column<Guid>(nullable: true),
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
                name: "Membros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    CipaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membros_Cipas_CipaId",
                        column: x => x.CipaId,
                        principalTable: "Cipas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cipas_Codigo",
                table: "Cipas",
                column: "Codigo",
                unique: true);

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
                name: "IX_Membros_CipaId",
                table: "Membros",
                column: "CipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Membros_UserName",
                table: "Membros",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estabelecimentos");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "Cipas");
        }
    }
}
