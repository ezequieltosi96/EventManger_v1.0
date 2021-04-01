
namespace EM.Dominio.Metadata
{
    using Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class BeneficioEntradaConfiguracion : IEntityTypeConfiguration<BeneficioEntrada>
    {
        public void Configure(EntityTypeBuilder<BeneficioEntrada> builder)
        {
            builder.ToTable("BeneficioEntrada");

            builder.Property(p => p.Nombre)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
