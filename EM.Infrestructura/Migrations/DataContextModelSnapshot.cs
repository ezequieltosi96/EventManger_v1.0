﻿// <auto-generated />
using System;
using EM.Infrestructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EM.Infrestructura.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EM.Dominio.Entidades.BeneficioEntrada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("BeneficioEntrada");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Direccion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("EstaEliminado");

                    b.Property<long>("LocalidadId");

                    b.Property<long>("ProvinciaId");

                    b.HasKey("Id");

                    b.HasIndex("LocalidadId");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Pais", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Persona", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Provincia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("PaisId");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.TipoEntrada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BeneficioEntradaId");

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BeneficioEntradaId");

                    b.ToTable("TipoEntrada");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Rol", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaEliminado");

                    b.Property<DateTime>("FechaAlta");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<long>("RolId");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Cliente", b =>
                {
                    b.HasBaseType("EM.Dominio.Entidades.Persona");

                    b.Property<long>("UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Clientes");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Direccion", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("LocalidadId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Localidad", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Provincia", "Provincia")
                        .WithMany()
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Provincia", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.TipoEntrada", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.BeneficioEntrada", "BeneficiosEntradas")
                        .WithMany()
                        .HasForeignKey("BeneficioEntradaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Usuario", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
