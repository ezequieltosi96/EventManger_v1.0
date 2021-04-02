namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClienteConfiguracion : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.Property(c => c.Nombre).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Apellido).HasMaxLength(100).IsRequired();
            builder.Property(c => c.Dni).HasMaxLength(8).IsRequired();
        }
    }
}
