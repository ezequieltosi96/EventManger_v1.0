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

            modelBuilder.Entity("EM.Dominio.Entidades.Actividad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DisertanteId");

                    b.Property<bool>("EstaEliminado");

                    b.Property<long>("EventoId");

                    b.Property<DateTime>("FechaHora");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<long>("SalaId");

                    b.HasKey("Id");

                    b.HasIndex("DisertanteId");

                    b.HasIndex("EventoId");

                    b.HasIndex("SalaId");

                    b.ToTable("Actividades");
                });

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

                    b.HasKey("Id");

                    b.HasIndex("LocalidadId");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Empresa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cuil")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<long>("DireccionId");

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("NombreFantasia")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("DireccionId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Entrada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClienteId");

                    b.Property<bool>("EstaEliminado");

                    b.Property<long>("EventoId");

                    b.Property<decimal>("Precio");

                    b.Property<long>("TipoEntradaId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EventoId");

                    b.HasIndex("TipoEntradaId");

                    b.ToTable("Entrada");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Establecimiento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DireccionId");

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("DireccionId");

                    b.ToTable("Establecimientos");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Evento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cupo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<long>("EmpresaId");

                    b.Property<bool>("EstaEliminado");

                    b.Property<long?>("EstablecimientoId");

                    b.Property<long>("EstalecimientoId");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("EstablecimientoId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Factura", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClienteId");

                    b.Property<long>("EmpresaId");

                    b.Property<bool>("EstaEliminado");

                    b.Property<long>("FormaPagoId");

                    b.Property<int>("TipoFactura");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("FormaPagoId");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.FacturaDetalle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad");

                    b.Property<long>("EntradaId");

                    b.Property<bool>("EstaEliminado");

                    b.Property<long>("FacturaId");

                    b.Property<decimal>("SubTotal");

                    b.HasKey("Id");

                    b.HasIndex("EntradaId");

                    b.HasIndex("FacturaId");

                    b.ToTable("FacturaDetalle");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.FormaPago", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("FormaPago");

                    b.HasDiscriminator<string>("Discriminator").HasValue("FormaPago");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Inscripcion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClienteId");

                    b.Property<long>("EntradaId");

                    b.Property<bool>("EstaEliminado");

                    b.Property<long>("EventoId");

                    b.Property<int>("InscripcionEstado");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EntradaId");

                    b.HasIndex("EventoId");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Localidad", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaEliminado");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("ProvinciaId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Localidades");
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

            modelBuilder.Entity("EM.Dominio.Entidades.Sala", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EstaEliminado");

                    b.Property<long>("EstablecimientoId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("EstablecimientoId");

                    b.ToTable("Salas");
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

            modelBuilder.Entity("EM.Dominio.Identity.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("EM.Dominio.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NombreMostrar");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.FormaPagoTarjeta", b =>
                {
                    b.HasBaseType("EM.Dominio.Entidades.FormaPago");

                    b.Property<int>("AnioExp");

                    b.Property<long>("CodigoPostal");

                    b.Property<string>("CodigoSeguridad")
                        .IsRequired();

                    b.Property<string>("DireccionFacturacion")
                        .IsRequired();

                    b.Property<string>("DireccionFacturacion2")
                        .IsRequired();

                    b.Property<int>("MesExp");

                    b.Property<int>("NumeroPagos");

                    b.Property<string>("NumeroTarjeta")
                        .IsRequired()
                        .HasMaxLength(16);

                    b.Property<long>("PaisId");

                    b.Property<decimal>("SubTotalCuota");

                    b.Property<int>("TipoTarjeta");

                    b.HasIndex("PaisId");

                    b.ToTable("FormaPagoTarjeta");

                    b.HasDiscriminator().HasValue("FormaPagoTarjeta");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Cliente", b =>
                {
                    b.HasBaseType("EM.Dominio.Entidades.Persona");

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.ToTable("Clientes");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Disertante", b =>
                {
                    b.HasBaseType("EM.Dominio.Entidades.Persona");

                    b.Property<long>("EmpresaId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Disertantes");

                    b.HasDiscriminator().HasValue("Disertante");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Actividad", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Disertante", "Disertante")
                        .WithMany()
                        .HasForeignKey("DisertanteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.Evento", "Evento")
                        .WithMany("Actividades")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Direccion", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Localidad", "Localidad")
                        .WithMany()
                        .HasForeignKey("LocalidadId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Empresa", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Direccion", "Direccion")
                        .WithMany()
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Entrada", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.Evento", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.TipoEntrada", "TiposEntradas")
                        .WithMany()
                        .HasForeignKey("TipoEntradaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Establecimiento", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Direccion", "Direccion")
                        .WithMany()
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Evento", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.Establecimiento", "Establecimiento")
                        .WithMany()
                        .HasForeignKey("EstablecimientoId");
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Factura", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.FormaPago", "FormaPago")
                        .WithMany()
                        .HasForeignKey("FormaPagoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.FacturaDetalle", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Entrada", "Entrada")
                        .WithMany()
                        .HasForeignKey("EntradaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.Factura", "Factura")
                        .WithMany()
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Inscripcion", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Cliente", "Clientes")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.Entrada", "Entradas")
                        .WithMany()
                        .HasForeignKey("EntradaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EM.Dominio.Entidades.Evento", "Eventos")
                        .WithMany()
                        .HasForeignKey("EventoId")
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

            modelBuilder.Entity("EM.Dominio.Entidades.Sala", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Establecimiento", "Establecimiento")
                        .WithMany()
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.TipoEntrada", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.BeneficioEntrada", "BeneficiosEntradas")
                        .WithMany()
                        .HasForeignKey("BeneficioEntradaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("EM.Dominio.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EM.Dominio.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EM.Dominio.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("EM.Dominio.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EM.Dominio.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EM.Dominio.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.FormaPagoTarjeta", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EM.Dominio.Entidades.Disertante", b =>
                {
                    b.HasOne("EM.Dominio.Entidades.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
