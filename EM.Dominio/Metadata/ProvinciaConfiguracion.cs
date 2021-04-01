using System;
using System.Collections.Generic;
using System.Text;
using EM.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EM.Dominio.Metadata
{
    public class ProvinciaConfiguracion : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> builder)
        {
            builder.ToTable("Provincias");

            builder.Property(p => p.Nombre).HasMaxLength(100).IsRequired();
        }
    }
}
