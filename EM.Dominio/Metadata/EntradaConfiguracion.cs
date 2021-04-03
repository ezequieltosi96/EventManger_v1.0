namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EntradaConfiguracion : IEntityTypeConfiguration<Entrada>
    {
        public void Configure(EntityTypeBuilder<Entrada> builder)
        {
            builder.ToTable("Entrada");

            builder.Property(e => e.Precio).IsRequired();
        }
    }
}
