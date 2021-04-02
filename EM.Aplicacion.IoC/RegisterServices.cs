using EM.Dominio.Repositorio.Cliente;
using EM.Dominio.Repositorio.Usuario;
using EM.Infrestructura.Repositorio.Cliente;
using EM.Infrestructura.Repositorio.Usuario;
using EM.IServicio.Cliente;
using EM.IServicio.Usuario;
using EM.Servicio.Cliente;
using EM.Servicio.Usuario;

namespace EM.Aplicacion.IoC
{
    using Dominio.Repositorio;
    using DominioBase;
    using Infrestructura;
    using Infrestructura.Repositorio;
    using Microsoft.Extensions.DependencyInjection;
    using IServicio.Pais;
    using Servicio.Pais;
    using AutoMapper;
    using EM.Dominio.Repositorio.Localidad;
    using EM.Dominio.Repositorio.Provincia;
    using EM.Infrestructura.Repositorio.Localidad;
    using EM.Infrestructura.Repositorio.Provincia;
    using EM.IServicio.Localidad;
    using EM.IServicio.Provincia;
    using EM.Servicio.Localidad;
    using EM.Servicio.Provincia;
    using EM.Dominio.Repositorio.BeneficioEntrada;
    using EM.Infrestructura.Repositorio.BeneficioEntrada;
    using EM.IServicio.BeneficioEntrada;
    using EM.Servicio.BeneficioEntrada;
    using EM.Dominio.Repositorio.Direccion;
    using EM.Infrestructura.Repositorio.Direccion;
    using EM.IServicio.Direccion;
    using EM.Servicio.Direccion;
    using EM.Dominio.Repositorio.TipoEntrada;
    using EM.Infrestructura.Repositorio.TipoEntrada;
    using EM.IServicio.TipoEntrada;
    using EM.Servicio.TipoEntrada;
    using EM.Dominio.Repositorio.Persona;
    using EM.IServicio.Persona;
    using EM.Servicio.Persona;
    using EM.Dominio.Repositorio.Rol;
    using EM.Infrestructura.Repositorio.Rol;
    using EM.IServicio.Rol;
    using EM.Servicio.Rol;


    public class RegisterServices
    {
        public void Register(IServiceCollection services)
        {
            // general
            services.AddDbContext<DataContext>();
            services.AddScoped<IRepositorio<EntidadBase>, Repositorio<EntidadBase>>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // pais
            services.AddTransient<IPaisRepositorio, PaisRepositorio>();
            services.AddTransient<IPaisServicio, PaisServicio>();

            // provincia
            services.AddTransient<IProvinciaRepositorio, ProvinciaRepositorio>();
            services.AddTransient<IProvinciaServicio, ProvinciaServicio>();

            // localidad
            services.AddTransient<ILocalidadRepositorio, LocalidadRepositorio>();
            services.AddTransient<ILocalidadServicio, LocalidadServicio>();

            //BeneficioEntrada
            services.AddTransient<IBeneficioEntradaRepositorio, BeneficioEntradaRepositorio>();
            services.AddTransient<IBeneficioEntradaServicio, BeneficioEntradaServicio>();

            // direccion
            services.AddTransient<IDireccionRepositorio, DireccionRepositorio>();
            services.AddTransient<IDireccionServicio, DireccionServicio>();

            // direccion
            services.AddTransient<ITipoEntradaRepositorio, TipoEntradaRepositorio>();
            services.AddTransient<ITipoEntradaServicio, TipoEntradaServicio>();

            // persona
            services.AddTransient<IPersonaRepositorio, PersonaRepositorio>();
            services.AddTransient<IPersonaServicio, PersonaServicio>();

            // rol
            services.AddTransient<IRolRepositorio, RolRepositorio>();
            services.AddTransient<IRolServicio, RolServicio>();

            // usuario
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<IUsuarioServicio, UsuarioServicio>();

            // cliente
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IClienteServicio, ClienteServicio>();
        }
    }
}
