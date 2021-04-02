using System;

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
            SeedLocalidades(context);
            SeedDirecciones(context);
            SeedBeneficiosEntradas(context);
            SeedTipoEntrada(context);
            SeedRoles(context);
            SeedUsuario(context);

            // Guardar cambios
            context.SaveChanges();
        }

        private static void SeedUsuario(DataContext context)
        {
            if (context.Usuarios.Any()) return;

            context.Usuarios.Add(new Usuario()
            {
                Mail = "admin@admin.com",
                Password = "123456789",
                FechaAlta = DateTime.Now,
                RolId = 1
            });
        }

        private static void SeedRoles(DataContext context)
        {
            if (context.Roles.Any()) return;

            var roles = new List<Rol>()
            {
                new Rol()
                {
                    //Id = 1,
                    Nombre = "admin",
                },
                new Rol()
                {
                    //Id = 2,
                    Nombre = "empresa",
                },
                new Rol()
                {
                    //Id = 3,
                    Nombre = "cliente",
                },
            };

            context.Roles.AddRange(roles);
        }

        private static void SeedDirecciones(DataContext context)
        {
            if (context.Direcciones.Any()) return;

            var direcciones = new List<Direccion>()
            {
                new Direccion()
                {
                   //Id = 1,
                    Descripcion = "Maipu 42",
                    LocalidadId = 7,
                },
                new Direccion()
                {
                   //Id = 2,
                    Descripcion = "Av. 25 de Mayo 654",
                    LocalidadId = 7,
                },
                new Direccion()
                {
                   //Id = 3,
                    Descripcion = "24 de Septiembre 1100",
                    LocalidadId = 11,
                },
                new Direccion()
                {
                   //Id = 4,
                    Descripcion = "Av. Mate dde Luna 3312",
                    LocalidadId = 11,
                },
            };

            context.Direcciones.AddRange(direcciones);

        }

        private static void SeedLocalidades(DataContext context)
        {
            if (context.Localidades.Any())
            {
                return;
            }

            // No especificar el Id ya que la db lo asigna automaticamente.
            // Solo lo dejo comentado para poder hacer las relaciones entre entidades
            var localidades = new List<Localidad>()
            {
                new Localidad()
                {
                   //Id = 1,
                    Nombre = "CABA",
                    ProvinciaId = 15,
                },
                new Localidad()
                {
                   //Id = 2,
                    Nombre = "Palermo",
                    ProvinciaId = 15,
                },
                new Localidad()
                {
                   //Id = 3,
                    Nombre = "Recoleta",
                    ProvinciaId = 15,
                },
                new Localidad()
                {
                   //Id = 4,
                    Nombre = "Chacarita",
                    ProvinciaId = 15,
                },
                new Localidad()
                {
                   //Id = 5,
                    Nombre = "San Miguel de Tucuman",
                    ProvinciaId = 16,
                },
                new Localidad()
                {
                   //Id = 6,
                    Nombre = "Tafi Viejo",
                    ProvinciaId = 16,
                },
                new Localidad()
                {
                   //Id = 7,
                    Nombre = "Mendoza",
                    ProvinciaId = 17,
                },
                new Localidad()
                {
                   //Id = 8,
                    Nombre = "Carlos Paz",
                    ProvinciaId = 18,
                },
                new Localidad()
                {
                   //Id = 9,
                    Nombre = "Las Condes",
                    ProvinciaId = 19,
                },
                new Localidad()
                {
                   //Id = 10,
                    Nombre = "Iquique",
                    ProvinciaId = 20,
                },
                new Localidad()
                {
                   //Id = 11,
                    Nombre = "Sao Pablo",
                    ProvinciaId = 21,
                },
                new Localidad()
                {
                   //Id = 12,
                    Nombre = "Brasilia",
                    ProvinciaId = 22,
                },
            };

            context.Localidades.AddRange(localidades);
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
                    PaisId = 19,
                },
                new Provincia()
                {
                   //Id = 2,
                    Nombre = "Tucuman",
                    PaisId = 19,
                },
                new Provincia()
                {
                   //Id = 3,
                    Nombre = "Mendoza",
                    PaisId = 19,
                },
                new Provincia()
                {
                   //Id = 4,
                    Nombre = "Cordoba",
                    PaisId = 19,
                },
                new Provincia()
                {
                   //Id = 5,
                    Nombre = "Santiago De Chile",
                    PaisId = 20,
                },
                new Provincia()
                {
                   //Id = 6,
                    Nombre = "Iquique",
                    PaisId = 20,
                },
                new Provincia()
                {
                   //Id = 7,
                    Nombre = "Sao Paulo",
                    PaisId = 21,
                },
                new Provincia()
                {
                   //Id = 8,
                    Nombre = "Brasilia",
                    PaisId = 21,
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
        private static void SeedBeneficiosEntradas(DataContext context)
        {
            if (context.BeneficiosEntradas.Any())
            {
                return;
            }

            // No especificar el Id ya que la db lo asigna automaticamente.
            // Solo lo dejo comentado para poder hacer las relaciones entre entidades
            var beneficioEntrada = new List<BeneficioEntrada>()
            {
                new BeneficioEntrada()
                {
                   //Id = 1,
                    Nombre = "Almuerzo",
                },
                new BeneficioEntrada()
                {
                   //Id = 2,
                    Nombre = "Cena",
                },
                new BeneficioEntrada()
                {
                   //Id = 3,
                    Nombre = "Camiceta",
                }
            };

            context.BeneficiosEntradas.AddRange(beneficioEntrada);
        }
        private static void SeedTipoEntrada(DataContext context)
        {
            if (context.TiposEntradas.Any())
            {
                return;
            }

            // No especificar el Id ya que la db lo asigna automaticamente.
            // Solo lo dejo comentado para poder hacer las relaciones entre entidades
            var tipoEntrada = new List<TipoEntrada>()
            {
                new TipoEntrada()
                {
                   //Id = 1,
                    Nombre = "Gold",
                    BeneficioEntradaId = 9
                },
                new TipoEntrada()
                {
                   //Id = 2,
                    Nombre = "Silver",
                    BeneficioEntradaId = 10
                },
                new TipoEntrada()
                {
                   //Id = 3,
                    Nombre = "Bronze",
                    BeneficioEntradaId = 11
                },
                new TipoEntrada()
                {
                   //Id = 4,
                    Nombre = "Free",
                    BeneficioEntradaId = 11
                }
            };

            context.TiposEntradas.AddRange(tipoEntrada);
        }
    }
}
