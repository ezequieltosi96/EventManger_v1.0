namespace EM.Infrestructura
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Dominio.Entidades;
    using Dominio.Metadata;
    using static Aplicacion.CadenaConexion.CadenaConexion;
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ObtenercadenaSql, provider => provider.CommandTimeout(40));

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuracion FluentApi
            modelBuilder.ApplyConfiguration(new PaisConfiguracion());
            modelBuilder.ApplyConfiguration(new ProvinciaConfiguracion());
            modelBuilder.ApplyConfiguration(new LocalidadConfiguracion());
            modelBuilder.ApplyConfiguration(new DireccionConfiguracion());
            modelBuilder.ApplyConfiguration(new BeneficioEntradaConfiguracion());
            modelBuilder.ApplyConfiguration(new PersonaConfiguracion());
            modelBuilder.ApplyConfiguration(new RolConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            modelBuilder.ApplyConfiguration(new TipoEntradaConfiguracion());
            modelBuilder.ApplyConfiguration(new ClienteConfiguracion());
            // fin configuracion FluentApi

            // Desactivar le borrado en cascada
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            // fin desactivar borrado en cascada

            base.OnModelCreating(modelBuilder);
        }

        // Declaracion de DbSet
        public DbSet<Pais> Paises { get; set; }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Localidad> Localidades { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<BeneficioEntrada> BeneficiosEntradas { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Rol> Roles { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<TipoEntrada> TiposEntradas { get; set; }
    }
}
