using EM.Dominio.Repositorio.Provincia;
using EM.Infrestructura.Repositorio.Provincia;
using EM.IServicio.Provincia;
using EM.Servicio.Provincia;

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
        }
    }
}
