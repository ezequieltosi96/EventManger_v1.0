namespace EM.Dominio.Metadata
{
    using Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class PaisConfiguracion : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises");

            builder.Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
