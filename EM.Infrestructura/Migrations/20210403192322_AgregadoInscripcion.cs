using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Infrestructura.Migrations
{
    public partial class AgregadoInscripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EstaEliminado = table.Column<bool>(nullable: false),
                    ClienteId = table.Column<long>(nullable: false),
                    EventoId = table.Column<long>(nullable: false),
                    EntradaId = table.Column<long>(nullable: false),
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
                        name: "FK_Inscripciones_Entrada_EntradaId",
                        column: x => x.EntradaId,
                        principalTable: "Entrada",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");
        }
    }
}
