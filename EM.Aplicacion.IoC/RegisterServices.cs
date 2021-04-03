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
    using EM.Dominio.Repositorio.Actividad;
    using EM.Dominio.Repositorio.Establecimiento;
    using EM.Dominio.Repositorio.Sala;
    using EM.Infrestructura.Repositorio.Actividad;
    using EM.Infrestructura.Repositorio.Establecimiento;
    using EM.Infrestructura.Repositorio.Sala;
    using EM.IServicio.Actividad;
    using EM.IServicio.Establecimiento;
    using EM.IServicio.Sala;
    using EM.Servicio.Actividad;
    using EM.Servicio.Establecimiento;
    using EM.Servicio.Sala;
    using EM.Dominio.Repositorio.Evento;
    using EM.Infrestructura.Repositorio.Evento;
    using EM.IServicio.Evento;
    using EM.Servicio.Evento;
    using EM.Dominio.Repositorio.Evento;
    using EM.Infrestructura.Repositorio.Evento;
    using EM.IServicio.Evento;
    using EM.Servicio.Evento;
    using EM.Dominio.Repositorio.Entrada;
    using EM.IServicio.Entrada;
    using EM.Servicio.Entrada;
    using EM.Infrestructura.Repositorio.Entrada;
    using EM.Dominio.Repositorio.Inscripcion;
    using EM.Infrestructura.Repositorio.Inscripcion;
    using EM.Servicio.Inscripcion;
    using EM.IServicio.Inscripcion;

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
            services.AddScoped<IPaisRepositorio, PaisRepositorio>();
            services.AddScoped<IPaisServicio, PaisServicio>();

            // provincia
            services.AddScoped<IProvinciaRepositorio, ProvinciaRepositorio>();
            services.AddScoped<IProvinciaServicio, ProvinciaServicio>();

            // localidad
            services.AddScoped<ILocalidadRepositorio, LocalidadRepositorio>();
            services.AddScoped<ILocalidadServicio, LocalidadServicio>();

            //BeneficioEntrada
            services.AddScoped<IBeneficioEntradaRepositorio, BeneficioEntradaRepositorio>();
            services.AddScoped<IBeneficioEntradaServicio, BeneficioEntradaServicio>();

            // direccion
            services.AddScoped<IDireccionRepositorio, DireccionRepositorio>();
            services.AddScoped<IDireccionServicio, DireccionServicio>();

            // direccion
            services.AddScoped<ITipoEntradaRepositorio, TipoEntradaRepositorio>();
            services.AddScoped<ITipoEntradaServicio, TipoEntradaServicio>();

            // persona
            services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
            services.AddScoped<IPersonaServicio, PersonaServicio>();

            // cliente
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IClienteServicio, ClienteServicio>();

            // empresa
            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddScoped<IEmpresaServicio, EmpresaServicio>();

            // disertante
            services.AddScoped<IDisertanteRepositorio, DisertanteRepositorio>();
            services.AddScoped<IDisertanteServicio, DisertanteServicio>();

            // establecimiento
            services.AddScoped<IEstablecimientoRepositorio, EstablecimientoRepositorio>();
            services.AddScoped<IEstablecimientoServicio, EstablecimientoServicio>();

            // sala
            services.AddScoped<ISalaRespositorio, SalaRepositorio>();
            services.AddScoped<ISalaServicio, SalaServicio>();

            // actividad
            services.AddScoped<IActividadRepositorio, ActividadRepositorio>();
            services.AddScoped<IActividadServicio, ActividadServicio>();

            // evento 
            services.AddScoped<IEventoRepositorio, EventoRepositorio>();
            services.AddScoped<IEventoServicio, EventoServicio>();
            services.AddSingleton<IEventoRepositorio, EventoRepositorio>();
            services.AddSingleton<IEventoServicio, EventoServicio>();

            //Entrada
            services.AddSingleton<IEntradaRepositorio, EntradaRepositorio>();
            services.AddSingleton<IEntradaServicio, EntradaServicio>();

            //Inscripcion
            services.AddSingleton<IInscripcionRepositorio, InscripcionRepositorio>();
            services.AddSingleton<IInscripcionServicio, InscripcionServicio>();
        }
    }
}
