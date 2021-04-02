namespace EM.Dominio.Metadata
{
    using EM.Dominio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DisertanteConfiguracion : IEntityTypeConfiguration<Disertante>
    {
        public void Configure(EntityTypeBuilder<Disertante> builder)
        {
            builder.ToTable("Disertantes");
        }
    }
}
