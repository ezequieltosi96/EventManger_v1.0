using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EM.Infrestructura.Migrations
{
    public partial class AgregadoEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EventoId",
                table: "Actividades",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 250, nullable: false),
                    Cupo = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EstalecimientoId = table.Column<long>(nullable: false),
                    EmpresaId = table.Column<long>(nullable: false),
                    EstablecimientoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_EventoId",
                table: "Actividades",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EmpresaId",
                table: "Eventos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EstablecimientoId",
                table: "Eventos",
                column: "EstablecimientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actividades_Eventos_EventoId",
                table: "Actividades",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actividades_Eventos_EventoId",
                table: "Actividades");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Actividades_EventoId",
                table: "Actividades");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Actividades");
        }
    }
}
