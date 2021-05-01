namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FacturaConfiguracion : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");

            builder.Property(f => f.Fecha).IsRequired();
            builder.Property(l => l.TipoFactura).IsRequired();
            builder.Property(t => t.Total).IsRequired();

            builder.HasMany(e => e.FacturaDetalles).WithOne(e => e.Factura).HasForeignKey(a => a.FacturaId);
        }
    }
}
