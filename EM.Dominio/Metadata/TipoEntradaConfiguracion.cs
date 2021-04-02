

namespace EM.Dominio.Metadata
{
    using Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class TipoEntradaConfiguracion : IEntityTypeConfiguration<TipoEntrada>
    {
        public void Configure(EntityTypeBuilder<TipoEntrada> builder)
        {
            builder.ToTable("TipoEntrada");

            builder.Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
