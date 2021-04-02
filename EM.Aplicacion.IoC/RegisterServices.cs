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
            services.AddScoped<IRepositorio<EntidadBase>, Repositorio<EntidadBase>>();

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

            // cliente
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            services.AddTransient<IClienteServicio, ClienteServicio>();

            // empresa
            services.AddTransient<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddTransient<IEmpresaServicio, EmpresaServicio>();
        }
    }
}
