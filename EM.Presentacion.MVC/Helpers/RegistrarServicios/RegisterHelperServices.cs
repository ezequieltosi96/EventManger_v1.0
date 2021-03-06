using EM.Presentacion.MVC.Helpers.Actividad;
using EM.Presentacion.MVC.Helpers.BeneficioEntrada;
using EM.Presentacion.MVC.Helpers.Cliente;
using EM.Presentacion.MVC.Helpers.Direccion;
using EM.Presentacion.MVC.Helpers.Disertante;
using EM.Presentacion.MVC.Helpers.Empresa;
using EM.Presentacion.MVC.Helpers.Entrada;
using EM.Presentacion.MVC.Helpers.Establecimiento;
using EM.Presentacion.MVC.Helpers.Evento;
using EM.Presentacion.MVC.Helpers.FormaPago;
using EM.Presentacion.MVC.Helpers.FormaPago.Tarjeta;
using EM.Presentacion.MVC.Helpers.Localidad;
using EM.Presentacion.MVC.Helpers.Pais;
using EM.Presentacion.MVC.Helpers.Provincia;
using EM.Presentacion.MVC.Helpers.Sala;
using EM.Presentacion.MVC.Helpers.TipoEntrada;
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
            services.AddScoped<IHelperEstablecimiento, HelperEstablecimiento>();
            services.AddScoped<IHelperActividad, HelperActividad>();
            services.AddScoped<IHelperDisertante, HelperDisertante>();
            services.AddScoped<IHelperSala, HelperSala>();
            services.AddScoped<IHelperBeneficioEntrada, HelperBeneficioEntrada>();
            services.AddScoped<IHelperFormaPago, HelperFormaPago>();
            services.AddScoped<IHelperFormaPagoTarjeta, HelperFormaPAgoTarjeta>();
            services.AddScoped<IHelperTipoEntrada, HelperTipoEntrada>();
            services.AddScoped<IHelperEvento, HelperEvento>();
            services.AddScoped<IHelperEntrada, HelperEntrada>();
        }
    }
}
