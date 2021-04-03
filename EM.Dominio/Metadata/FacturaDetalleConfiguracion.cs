namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FacturaDetalleConfiguracion : IEntityTypeConfiguration<FacturaDetalle>
    {
        public void Configure(EntityTypeBuilder<FacturaDetalle> builder)
        {
            builder.ToTable("FacturaDetalle");

            builder.Property(l => l.Cantidad).IsRequired();
            builder.Property(t => t.SubTotal).IsRequired();
        }
    }
}
