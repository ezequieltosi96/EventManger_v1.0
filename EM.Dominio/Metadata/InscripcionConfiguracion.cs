namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InscripcionConfiguracion : IEntityTypeConfiguration<Inscripcion>
    {
        public void Configure(EntityTypeBuilder<Inscripcion> builder)
        {
            builder.ToTable("Inscripciones");

            builder.Property(l => l.InscripcionEstado).IsRequired();

        }
    }
}
