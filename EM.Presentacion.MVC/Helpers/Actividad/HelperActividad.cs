using EM.IServicio.Actividad;
using EM.IServicio.Actividad.Dto;
using EM.IServicio.Disertante.Dto;
using EM.IServicio.Sala.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<bool> ExistePorDisertanteYFecha(long disertanteId, DateTime fecha)
        {
            var actividades =
                (IEnumerable<ActividadDto>)await _actividadServicio.ObtenerPorDisertanteYFecha(disertanteId, fecha);

            return actividades.Any();
        }

        public async Task<IEnumerable<SalaDto>> FiltrarSalasDisponibles(IEnumerable<SalaDto> salas, DateTime? fecha)
        {
            if (!fecha.HasValue) return salas;

            foreach (var sala in salas)
            {
                if (ExistePorSalaYFecha(sala.Id, fecha.Value).Result)
                {
                    salas = salas.Where(s => s.Id != sala.Id);
                }
            }

            return salas;
        }

        public async Task<IEnumerable<DisertanteDto>> FiltrarDisertantesDisponibles(IEnumerable<DisertanteDto> disertantes, DateTime? fecha = null)
        {
            if (!fecha.HasValue) return disertantes;

            foreach (var disertante in disertantes)
            {
                if (ExistePorDisertanteYFecha(disertante.Id, fecha.Value).Result)
                {
                    disertantes = disertantes.Where(d => d.Id != disertante.Id);
                }
            }

            return disertantes;
        }


    }
}
