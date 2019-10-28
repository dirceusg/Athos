using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Athos.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradora",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    TipoAssunto = table.Column<int>(nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(100)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condominio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    AdministradoraId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condominio_Administradora_AdministradoraId",
                        column: x => x.AdministradoraId,
                        principalTable: "Administradora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false),
                    CondominioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Condominio_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Condominio_AdministradoraId",
                table: "Condominio",
                column: "AdministradoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CondominioId",
                table: "Usuario",
                column: "CondominioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Condominio");

            migrationBuilder.DropTable(
                name: "Administradora");
        }
    }
}
