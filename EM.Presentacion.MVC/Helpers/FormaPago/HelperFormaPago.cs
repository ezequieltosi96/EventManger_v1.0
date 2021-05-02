using EM.IServicio.FormaPago;
using EM.IServicio.FormaPago.Dto;
using EM.Presentacion.MVC.Models.FormaPago;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.FormaPago
{
    public class HelperFormaPago : IHelperFormaPago
    {
        private readonly IFormaPagoServicio _formaPagoServicio;

        public HelperFormaPago(IFormaPagoServicio formaPagoServicio)
        {
            _formaPagoServicio = formaPagoServicio;
        }

        public async Task<FormaPagoViewModel> ObtenerFormaPago(long id)
        {
            var dto = (FormaPagoDto)await _formaPagoServicio.Obtener(id);

            var model = new FormaPagoViewModel()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                EstaEliminado = dto.EliminadoStr,
            };

            return model;
        }

        public async Task<IEnumerable<SelectListItem>> PoblarCombo()
        {
            var formasPago = (IEnumerable<FormaPagoDto>)await _formaPagoServicio.Obtener(String.Empty, false);

            return new SelectList(formasPago, "Id", "Nombre");
        }
    }
}
