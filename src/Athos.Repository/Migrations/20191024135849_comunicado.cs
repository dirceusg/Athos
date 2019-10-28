using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Athos.Repository.Migrations
{
    public partial class comunicado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mensagem",
                table: "Assunto");

            migrationBuilder.CreateTable(
                name: "Comunicado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    RemetenteId = table.Column<Guid>(nullable: false),
                    AssuntoId = table.Column<Guid>(nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(100)", maxLength: 3000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunicado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunicado_Assunto_AssuntoId",
                        column: x => x.AssuntoId,
                        principalTable: "Assunto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comunicado_Usuario_RemetenteId",
                        column: x => x.RemetenteId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComunicadoAcao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    DataAcao = table.Column<DateTime>(nullable: false),
                    ComunicadoId = table.Column<Guid>(nullable: false),
                    TipoAcaoComunicado = table.Column<int>(nullable: false),
                    ExecutorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunicadoAcao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComunicadoAcao_Comunicado_ComunicadoId",
                        column: x => x.ComunicadoId,
                        principalTable: "Comunicado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComunicadoAcao_Usuario_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comunicado_AssuntoId",
                table: "Comunicado",
                column: "AssuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comunicado_RemetenteId",
                table: "Comunicado",
                column: "RemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunicadoAcao_ComunicadoId",
                table: "ComunicadoAcao",
                column: "ComunicadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunicadoAcao_ExecutorId",
                table: "ComunicadoAcao",
                column: "ExecutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComunicadoAcao");

            migrationBuilder.DropTable(
                name: "Comunicado");

            migrationBuilder.AddColumn<string>(
                name: "Mensagem",
                table: "Assunto",
                type: "varchar(100)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");
        }
    }
}
