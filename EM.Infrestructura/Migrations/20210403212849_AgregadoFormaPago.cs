using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Infrestructura.Migrations
{
    public partial class AgregadoFormaPago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "FormaPago",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AnioExp",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CodigoPostal",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoSeguridad",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DireccionFacturacion",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DireccionFacturacion2",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MesExp",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPagos",
                table: "FormaPago",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTarjeta",
                table: "FormaPago",
                maxLength: 16,
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

            migrationBuilder.AddColumn<long>(
                name: "FormaPagoId",
                table: "Factura",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_FormaPago_PaisId",
                table: "FormaPago",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_FormaPagoId",
                table: "Factura",
                column: "FormaPagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_FormaPago_FormaPagoId",
                table: "Factura",
                column: "FormaPagoId",
                principalTable: "FormaPago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormaPago_Paises_PaisId",
                table: "FormaPago",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_FormaPago_FormaPagoId",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_FormaPago_Paises_PaisId",
                table: "FormaPago");

            migrationBuilder.DropIndex(
                name: "IX_FormaPago_PaisId",
                table: "FormaPago");

            migrationBuilder.DropIndex(
                name: "IX_Factura_FormaPagoId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "AnioExp",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "CodigoSeguridad",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "DireccionFacturacion",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "DireccionFacturacion2",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "MesExp",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "NumeroPagos",
                table: "FormaPago");

            migrationBuilder.DropColumn(
                name: "NumeroTarjeta",
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

            migrationBuilder.DropColumn(
                name: "FormaPagoId",
                table: "Factura");
        }
    }
}
