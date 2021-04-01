using System;
using System.Collections.Generic;
using System.Text;
using EM.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EM.Dominio.Metadata
{
    public class DireccionConfiguracion : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.ToTable("Direcciones");

            builder.Property(d => d.Descripcion).HasMaxLength(250).IsRequired();
        }
    }
}
