using EM.Presentacion.MVC.Helpers.Pais;
using Microsoft.Extensions.DependencyInjection;

namespace EM.Presentacion.MVC.Helpers.RegistrarServicios
{
    public static class RegisterHelperServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IHelperPais, HelperPais>();
        }
    }
}
