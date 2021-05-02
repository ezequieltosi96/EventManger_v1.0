using EM.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EM.Dominio.Metadata
{
    public class SalaConfiguracion : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("Salas");

            builder.Property(s => s.Nombre).HasMaxLength(200).IsRequired();
        }
    }
}
