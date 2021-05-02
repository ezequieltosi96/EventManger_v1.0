namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FormaPagoTarjetaConfiguracion : IEntityTypeConfiguration<FormaPagoTarjeta>
    {
        public void Configure(EntityTypeBuilder<FormaPagoTarjeta> builder)
        {
            builder.ToTable("FormaPagoTarjeta");

            builder.Property(f => f.NumeroTarjeta)
                .HasMaxLength(16)
                .IsRequired();
            builder.Property(f => f.MesExp)
                .IsRequired();
            builder.Property(f => f.AnioExp)
                .IsRequired();
            builder.Property(f => f.CodigoSeguridad)
                .IsRequired();
            builder.Property(f => f.DireccionFacturacion)
                .IsRequired();
            builder.Property(f => f.CodigoPostal)
               .IsRequired();
        }
    }
}
