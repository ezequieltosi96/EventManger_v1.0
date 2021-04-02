using EM.Dominio.Repositorio.Establecimiento;
using EM.Infrestructura.Repositorio.Establecimiento;
using EM.IServicio.Establecimiento;
using EM.Servicio.Establecimiento;

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
    using EM.Dominio.Repositorio.Cliente;
    using EM.Infrestructura.Repositorio.Cliente;
    using EM.IServicio.Cliente;
    using EM.Servicio.Cliente;
    using EM.Dominio.Identity;
    using EM.Dominio.Repositorio.Empresa;
    using EM.Infrestructura.Repositorio.Empresa;
    using EM.IServicio.Empresa;
    using EM.Servicio.Empresa;
    using EM.Dominio.Repositorio.Disertante;
    using EM.Infrestructura.Repositorio.Disertante;
    using EM.IServicio.Disertante;
    using EM.Servicio.Disertante;

    public static class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            // dbContext
            services.AddDbContext<DataContext>();
            // identity
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<DataContext>();
            // automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            // repositorio base
            services.AddSingleton<IRepositorio<EntidadBase>, Repositorio<EntidadBase>>();

            // pais
            services.AddSingleton<IPaisRepositorio, PaisRepositorio>();
            services.AddSingleton<IPaisServicio, PaisServicio>();

            // provincia
            services.AddSingleton<IProvinciaRepositorio, ProvinciaRepositorio>();
            services.AddSingleton<IProvinciaServicio, ProvinciaServicio>();

            // localidad
            services.AddSingleton<ILocalidadRepositorio, LocalidadRepositorio>();
            services.AddSingleton<ILocalidadServicio, LocalidadServicio>();

            //BeneficioEntrada
            services.AddSingleton<IBeneficioEntradaRepositorio, BeneficioEntradaRepositorio>();
            services.AddSingleton<IBeneficioEntradaServicio, BeneficioEntradaServicio>();

            // direccion
            services.AddSingleton<IDireccionRepositorio, DireccionRepositorio>();
            services.AddSingleton<IDireccionServicio, DireccionServicio>();

            // direccion
            services.AddSingleton<ITipoEntradaRepositorio, TipoEntradaRepositorio>();
            services.AddSingleton<ITipoEntradaServicio, TipoEntradaServicio>();

            // persona
            services.AddSingleton<IPersonaRepositorio, PersonaRepositorio>();
            services.AddSingleton<IPersonaServicio, PersonaServicio>();

            // cliente
            services.AddSingleton<IClienteRepositorio, ClienteRepositorio>();
            services.AddSingleton<IClienteServicio, ClienteServicio>();

            // empresa
            services.AddSingleton<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddSingleton<IEmpresaServicio, EmpresaServicio>();

            // disertante
            services.AddSingleton<IDisertanteRepositorio, DisertanteRepositorio>();
            services.AddSingleton<IDisertanteServicio, DisertanteServicio>();

            // establecimiento
            services.AddSingleton<IEstablecimientoRepositorio, EstablecimientoRepositorio>();
            services.AddSingleton<IEstablecimientoServicio, EstablecimientoServicio>();
        }
    }
}
