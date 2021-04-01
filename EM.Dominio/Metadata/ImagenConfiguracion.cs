namespace EM.Dominio.Metadata
{
    using Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ImagenConfiguracion : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> builder)
        {
            builder.ToTable("Imagen");

            builder.Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Data)
                .IsRequired();
        }
    }
}