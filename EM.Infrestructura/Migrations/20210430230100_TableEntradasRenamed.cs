using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Infrestructura.Migrations
{
    public partial class TableEntradasRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Personas_ClienteId",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_Eventos_EventoId",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrada_TipoEntrada_TipoEntradaId",
                table: "Entrada");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaDetalle_Entrada_EntradaId",
                table: "FacturaDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Entrada_EntradaId",
                table: "Inscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrada",
                table: "Entrada");

            migrationBuilder.RenameTable(
                name: "Entrada",
                newName: "Entradas");

            migrationBuilder.RenameIndex(
                name: "IX_Entrada_TipoEntradaId",
                table: "Entradas",
                newName: "IX_Entradas_TipoEntradaId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrada_EventoId",
                table: "Entradas",
                newName: "IX_Entradas_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Entrada_ClienteId",
                table: "Entradas",
                newName: "IX_Entradas_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entradas",
                table: "Entradas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Personas_ClienteId",
                table: "Entradas",
                column: "ClienteId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_Eventos_EventoId",
                table: "Entradas",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entradas_TipoEntrada_TipoEntradaId",
                table: "Entradas",
                column: "TipoEntradaId",
                principalTable: "TipoEntrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaDetalle_Entradas_EntradaId",
                table: "FacturaDetalle",
                column: "EntradaId",
                principalTable: "Entradas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Entradas_EntradaId",
                table: "Inscripciones",
                column: "EntradaId",
                principalTable: "Entradas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Personas_ClienteId",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_Eventos_EventoId",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_Entradas_TipoEntrada_TipoEntradaId",
                table: "Entradas");

            migrationBuilder.DropForeignKey(
                name: "FK_FacturaDetalle_Entradas_EntradaId",
                table: "FacturaDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Entradas_EntradaId",
                table: "Inscripciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entradas",
                table: "Entradas");

            migrationBuilder.RenameTable(
                name: "Entradas",
                newName: "Entrada");

            migrationBuilder.RenameIndex(
                name: "IX_Entradas_TipoEntradaId",
                table: "Entrada",
                newName: "IX_Entrada_TipoEntradaId");

            migrationBuilder.RenameIndex(
                name: "IX_Entradas_EventoId",
                table: "Entrada",
                newName: "IX_Entrada_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Entradas_ClienteId",
                table: "Entrada",
                newName: "IX_Entrada_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrada",
                table: "Entrada",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Personas_ClienteId",
                table: "Entrada",
                column: "ClienteId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_Eventos_EventoId",
                table: "Entrada",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Entrada_TipoEntrada_TipoEntradaId",
                table: "Entrada",
                column: "TipoEntradaId",
                principalTable: "TipoEntrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FacturaDetalle_Entrada_EntradaId",
                table: "FacturaDetalle",
                column: "EntradaId",
                principalTable: "Entrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Entrada_EntradaId",
                table: "Inscripciones",
                column: "EntradaId",
                principalTable: "Entrada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
