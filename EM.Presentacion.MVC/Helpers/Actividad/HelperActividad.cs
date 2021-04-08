using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Actividad;
using EM.IServicio.Actividad.Dto;

namespace EM.Presentacion.MVC.Helpers.Actividad
{
    public class HelperActividad : IHelperActividad
    {
        private readonly IActividadServicio _actividadServicio;

        public HelperActividad(IActividadServicio actividadServicio)
        {
            _actividadServicio = actividadServicio;
        }

        public async Task<bool> ExistePorSalaYFecha(long salaId, DateTime fecha, long? eventoId = null)
        {
            var actividades = (IEnumerable<ActividadDto>)await _actividadServicio.ObtenerPorSalaYFecha(salaId, fecha, eventoId);

            return actividades.Any();
        }
    }
}
