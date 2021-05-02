using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Infrestructura.Migrations
{
    public partial class FormaPagoTarjetaModificada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormaPago_Paises_PaisId",
                table: "FormaPago");

            migrationBuilder.DropIndex(
                name: "IX_FormaPago_PaisId",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "DireccionFacturacion2",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "NumeroPagos",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "SubTotalCuota",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "TipoTarjeta",
                table: "FormaPago");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DireccionFacturacion2",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPagos",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PaisId",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotalCuota",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoTarjeta",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormaPago_PaisId",
                table: "FormaPago",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormaPago_Paises_PaisId",
                table: "FormaPago",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
