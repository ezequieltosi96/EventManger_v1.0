using EM.IServicio.Disertante;
using EM.IServicio.Disertante.Dto;
using EM.Presentacion.MVC.Helpers.Actividad;
using EM.Presentacion.MVC.Models.Disertante;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Disertante
{
    public class HelperDisertante : IHelperDisertante
    {
        private readonly IDisertanteServicio _disertanteServicio;
        private readonly IHelperActividad _helperActividad;

        public HelperDisertante(IDisertanteServicio disertanteServicio, IHelperActividad helperActividad)
        {
            _disertanteServicio = disertanteServicio;
            _helperActividad = helperActividad;
        }

        public async Task<DisertanteViewModel> ObtenerDisertante(long id)
        {
            var dto = (DisertanteDto)await _disertanteServicio.Obtener(id);

            var model = new DisertanteViewModel()
            {
                Id = dto.Id,
                EstaEliminado = dto.EliminadoStr,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                EmpresaId = dto.EmpresaId
            };

            return model;
        }

        public async Task<IEnumerable<SelectListItem>> PoblarComboPorEmpresa(long empresaId, DateTime? fecha = null)
        {
            var disertantes = (IEnumerable<DisertanteDto>)await _disertanteServicio.ObtenerPorEmpresa(empresaId, String.Empty, false);

            var disertantesDisponibles = await _helperActividad.FiltrarDisertantesDisponibles(disertantes, fecha);

            var disertantesVms = disertantesDisponibles.Select(d => new DisertanteViewModel()
            {
                Apellido = d.Apellido,
                Nombre = d.Nombre,
                EstaEliminado = d.EliminadoStr,
                Id = d.Id,
                EmpresaId = d.EmpresaId,
                Dni = d.Dni,
            }).ToList();

            return new SelectList(disertantesVms, "Id", "ApyNom");
        }
    }
}
