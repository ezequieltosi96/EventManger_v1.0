using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Infrestructura.Migrations
{
    public partial class UpdateTipoEntradaWithEmpresaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.AddColumn<long>(
                name: "EmpresaId",
                table: "TipoEntrada",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TipoEntrada_EmpresaId",
                table: "TipoEntrada",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoEntrada_Empresas_EmpresaId",
                table: "TipoEntrada",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoEntrada_Empresas_EmpresaId",
                table: "TipoEntrada");

            migrationBuilder.DropIndex(
                name: "IX_TipoEntrada_EmpresaId",
                table: "TipoEntrada");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "TipoEntrada");

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<long>(nullable: false),
                    EntradaId = table.Column<long>(nullable: false),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    EventoId = table.Column<long>(nullable: false),
                    InscripcionEstado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Personas_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Entradas_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entradas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ClienteId",
                table: "Inscripciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EntradaId",
                table: "Inscripciones",
                column: "EntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoId",
                table: "Inscripciones",
                column: "EventoId");
        }
    }
}
