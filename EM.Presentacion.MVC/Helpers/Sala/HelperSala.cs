using EM.IServicio.Sala;
using EM.IServicio.Sala.Dto;
using EM.Presentacion.MVC.Helpers.Actividad;
using EM.Presentacion.MVC.Models.Sala;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Sala
{
    public class HelperSala : IHelperSala
    {
        private readonly ISalaServicio _salaServicio;
        private readonly IHelperActividad _helperActividad;

        public HelperSala(ISalaServicio salaServicio, IHelperActividad helperActividad)
        {
            _salaServicio = salaServicio;
            _helperActividad = helperActividad;
        }

        public async Task<SalaViewModel> ObtenerSala(long id)
        {
            var dto = (SalaDto)await _salaServicio.Obtener(id);

            var modelo = new SalaViewModel()
            {
                Id = dto.Id,
                EstaEliminado = dto.EliminadoStr,
                Nombre = dto.Nombre,
                EstablecimientoId = dto.EstablecimientoId
            };

            return modelo;
        }

        public async Task<bool> ExisteSalaDisponible(long establecimientoId, DateTime fecha, long? eventoId = null)
        {
            var salas = (IEnumerable<SalaDto>)await _salaServicio.ObtenerPorEstablecimiento(establecimientoId);

            foreach (var sala in salas)
            {
                var existeActividad = await _helperActividad.ExistePorSalaYFecha(sala.Id, fecha, eventoId);
                if (!existeActividad)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<IEnumerable<SelectListItem>> PoblarComboPorEstablecimiento(long establecimientoId, DateTime? fecha = null)
        {
            var salas = (IEnumerable<SalaDto>)await _salaServicio.ObtenerPorEstablecimiento(establecimientoId, String.Empty, false);

            var salasDisponibles = await _helperActividad.FiltrarSalasDisponibles(salas, fecha);

            return new SelectList(salasDisponibles, "Id", "Nombre");
        }
    }
}
