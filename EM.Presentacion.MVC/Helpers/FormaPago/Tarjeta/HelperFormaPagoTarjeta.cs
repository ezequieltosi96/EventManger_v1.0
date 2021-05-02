using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.FormaPagoTarjeta;
using EM.IServicio.FormaPagoTarjeta.Dto;
using EM.Presentacion.MVC.Models.FormaPagoTarjeta;

namespace EM.Presentacion.MVC.Helpers.FormaPago.Tarjeta
{
    public class HelperFormaPAgoTarjeta : IHelperFormaPagoTarjeta
    {
        private readonly IFormaPagoTarjetaServicio _formaPagoTarjetaServicio;

        public HelperFormaPAgoTarjeta(IFormaPagoTarjetaServicio formaPagoTarjetaServicio)
        {
            _formaPagoTarjetaServicio = formaPagoTarjetaServicio;
        }

        public async Task<FormaPagoTarjetaViewModel> Obtener(long id)
        {
            var dto = (FormaPagoTarjetaDto)await _formaPagoTarjetaServicio.Obtener(id);

            var model = new FormaPagoTarjetaViewModel()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                NumeroTarjeta = dto.NumeroTarjeta,
                AnioExp = dto.AnioExp,
                MesExp = dto.MesExp,
                CodigoSeguridad = dto.CodigoSeguridad,
                CodigoPostal = dto.CodigoPostal,
                DireccionFacturacion = dto.DireccionFacturacion,
                EstaEliminado = dto.EliminadoStr
            };

            return model;
        }
    }
}
