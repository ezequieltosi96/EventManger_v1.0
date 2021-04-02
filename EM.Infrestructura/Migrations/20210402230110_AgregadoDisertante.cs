using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Infrestructura.Migrations
{
    public partial class AgregadoDisertante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmpresaId",
                table: "Personas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EmpresaId",
                table: "Personas",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Empresas_EmpresaId",
                table: "Personas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Empresas_EmpresaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_EmpresaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Personas");
        }
    }
}
