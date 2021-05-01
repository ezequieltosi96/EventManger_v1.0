namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventoConfiguracion : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Eventos");

            builder.Property(e => e.Nombre).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Descripcion).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Fecha).IsRequired();
            builder.Property(e => e.Cupo).IsRequired();
            builder.Property(e => e.CupoDisponible).IsRequired();

            builder.HasMany(e => e.Actividades).WithOne(a => a.Evento).HasForeignKey(a => a.EventoId);
        }
    }
}
