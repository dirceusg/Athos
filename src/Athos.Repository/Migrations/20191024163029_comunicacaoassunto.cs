using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Athos.Repository.Migrations
{
    public partial class comunicacaoassunto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comunicado_Assunto_AssuntoId",
                table: "Comunicado");

            migrationBuilder.DropIndex(
                name: "IX_Comunicado_AssuntoId",
                table: "Comunicado");

            migrationBuilder.DropColumn(
                name: "AssuntoId",
                table: "Comunicado");

            migrationBuilder.AddColumn<int>(
                name: "TipoAssunto",
                table: "Comunicado",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoAssunto",
                table: "Comunicado");

            migrationBuilder.AddColumn<Guid>(
                name: "AssuntoId",
                table: "Comunicado",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comunicado_AssuntoId",
                table: "Comunicado",
                column: "AssuntoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comunicado_Assunto_AssuntoId",
                table: "Comunicado",
                column: "AssuntoId",
                principalTable: "Assunto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
