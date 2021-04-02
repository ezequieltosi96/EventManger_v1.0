namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(u => u.Mail).HasMaxLength(200).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(250).IsRequired();
            builder.Property(u => u.FechaAlta).IsRequired();
        }
    }
}
