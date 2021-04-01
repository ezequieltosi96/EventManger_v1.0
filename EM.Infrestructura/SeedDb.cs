namespace EM.Infrestructura
{
    using System.Collections.Generic;
    using System.Linq;
    using Dominio.Entidades;

    public static class SeedDb
    {
        public static void Seed(DataContext context)
        {
            context.Database.EnsureCreated();

            // Metodos seed
            SeedPaises(context);
            SeedProvincias(context);

            // Guardar cambios
            context.SaveChanges();
        }

        private static void SeedProvincias(DataContext context)
        {
            if (context.Provincias.Any())
            {
                return;
            }

            // No especificar el Id ya que la db lo asigna automaticamente.
            // Solo lo dejo comentado para poder hacer las relaciones entre entidades
            var provincias = new List<Provincia>()
            {
                new Provincia()
                {
                    //Id = 1,
                    Nombre = "Buenos Aires",
                    PaisId = 1,
                },
                new Provincia()
                {
                    //Id = 2,
                    Nombre = "Tucuman",
                    PaisId = 1,
                },
                new Provincia()
                {
                    //Id = 3,
                    Nombre = "Mendoza",
                    PaisId = 1,
                },
                new Provincia()
                {
                    //Id = 4,
                    Nombre = "Cordoba",
                    PaisId = 1,
                },
                new Provincia()
                {
                    //Id = 5,
                    Nombre = "Santiago De Chile",
                    PaisId = 2,
                },
                new Provincia()
                {
                    //Id = 6,
                    Nombre = "Iquique",
                    PaisId = 2,
                },
                new Provincia()
                {
                    //Id = 7,
                    Nombre = "Sao Paulo",
                    PaisId = 3,
                },
                new Provincia()
                {
                    //Id = 8,
                    Nombre = "Brasilia",
                    PaisId = 3,
                },
            };

            context.Provincias.AddRange(provincias);
        }

        private static void SeedPaises(DataContext context)
        {
            if (context.Paises.Any())
            {
                return;
            }

            // No especificar el Id ya que la db lo asigna automaticamente.
            // Solo lo dejo comentado para poder hacer las relaciones entre entidades
            var paises = new List<Pais>()
            {
                new Pais()
                {
                    //Id = 1,
                    Nombre = "Argentina",
                },
                new Pais()
                {
                    //Id = 2,
                    Nombre = "Chile",
                },
                new Pais()
                {
                    //Id = 3,
                    Nombre = "Brasil",
                }
            };

            context.Paises.AddRange(paises);
        }
    }
}
