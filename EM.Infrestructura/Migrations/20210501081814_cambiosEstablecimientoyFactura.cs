using Microsoft.EntityFrameworkCore.Migrations;

namespace EM.Infrestructura.Migrations
{
    public partial class cambiosEstablecimientoyFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstalecimientoId",
                table: "Eventos");

            migrationBuilder.AlterColumn<long>(
                name: "EstablecimientoId",
                table: "Eventos",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "EstablecimientoId",
                table: "Eventos",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "EstalecimientoId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
