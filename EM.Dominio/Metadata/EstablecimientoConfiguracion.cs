using EM.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EM.Dominio.Metadata
{
    public class EstablecimientoConfiguracion : IEntityTypeConfiguration<Establecimiento>
    {
        public void Configure(EntityTypeBuilder<Establecimiento> builder)
        {
            builder.ToTable("Establecimientos");

            builder.Property(e => e.Nombre).HasMaxLength(200).IsRequired();
        }
    }
}
