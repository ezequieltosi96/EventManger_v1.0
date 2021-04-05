using EM.Presentacion.MVC.Helpers.Cliente;
using EM.Presentacion.MVC.Helpers.Direccion;
using EM.Presentacion.MVC.Helpers.Empresa;
using EM.Presentacion.MVC.Helpers.Localidad;
using EM.Presentacion.MVC.Helpers.Pais;
using EM.Presentacion.MVC.Helpers.Provincia;
using Microsoft.Extensions.DependencyInjection;

namespace EM.Presentacion.MVC.Helpers.RegistrarServicios
{
    public static class RegisterHelperServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IHelperPais, HelperPais>();
            services.AddScoped<IHelperProvincia, HelperProvincia>();
            services.AddScoped<IHelperCliente, HelperCliente>();
            services.AddScoped<IHelperDireccion, HelperDireccion>();
            services.AddScoped<IHelperEmpresa, HelperEmpresa>();
            services.AddScoped<IHelperLocalidad, HelperLocalidad>();
        }
    }
}
