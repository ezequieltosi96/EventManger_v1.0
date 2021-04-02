namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PersonaConfiguracion : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Personas");

            builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Apellido).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Dni).HasMaxLength(8).IsRequired();
        }
    }
}
