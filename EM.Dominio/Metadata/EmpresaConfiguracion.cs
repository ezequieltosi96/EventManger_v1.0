namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmpresaConfiguracion : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas");

            builder.Property(e => e.RazonSocial).HasMaxLength(200).IsRequired();
            builder.Property(e => e.NombreFantasia).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Cuil).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(200).IsRequired(false);
        }
    }
}
