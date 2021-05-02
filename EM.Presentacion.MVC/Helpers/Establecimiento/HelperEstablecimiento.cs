using EM.IServicio.Establecimiento;
using EM.IServicio.Establecimiento.Dto;
using EM.Presentacion.MVC.Helpers.Direccion;
using EM.Presentacion.MVC.Models.Establecimiento;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Establecimiento
{
    public class HelperEstablecimiento : IHelperEstablecimiento
    {
        private readonly IEstablecimientoServicio _establecimientoServicio;
        private readonly IHelperDireccion _helperDireccion;

        public HelperEstablecimiento(IEstablecimientoServicio establecimientoServicio, IHelperDireccion helperDireccion)
        {
            _establecimientoServicio = establecimientoServicio;
            _helperDireccion = helperDireccion;
        }

        public async Task<EstablecimientoViewModel> ObtenerEstablecimiento(long id)
        {
            var dto = (EstablecimientoDto)await _establecimientoServicio.Obtener(id);

            var model = new EstablecimientoViewModel()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                DireccionId = dto.DireccionId,
                EstaEliminado = dto.EliminadoStr,
                Direccion = await _helperDireccion.ObtenerDireccion(dto.DireccionId),
            };

            return model;
        }

        public async Task<IEnumerable<SelectListItem>> PoblarCombo()
        {
            var establecimientos =
                (IEnumerable<EstablecimientoDto>)await _establecimientoServicio.Obtener(String.Empty, false);

            return new SelectList(establecimientos, "Id", "Nombre");
        }
    }
}
