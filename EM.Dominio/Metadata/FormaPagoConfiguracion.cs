namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FormaPagoConfiguracion : IEntityTypeConfiguration<FormaPago>
    {
        public void Configure(EntityTypeBuilder<FormaPago> builder)
        {
            builder.ToTable("FormaPago");

            builder.Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
