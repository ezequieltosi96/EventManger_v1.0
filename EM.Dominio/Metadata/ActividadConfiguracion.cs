namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ActividadConfiguracion : IEntityTypeConfiguration<Actividad>
    {
        public void Configure(EntityTypeBuilder<Actividad> builder)
        {
            builder.ToTable("Actividades");

            builder.Property(a => a.Nombre).HasMaxLength(150).IsRequired();
            builder.Property(a => a.FechaHora).IsRequired();
        }
    }
}
