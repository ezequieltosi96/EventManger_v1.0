using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.Disertante.Dto;
using EM.IServicio.Sala.Dto;

namespace EM.Presentacion.MVC.Helpers.Actividad
{
    public interface IHelperActividad
    {
        Task<bool> ExistePorSalaYFecha(long salaId, DateTime fecha, long? eventoId = null);

        Task<IEnumerable<SalaDto>> FiltrarSalasDisponibles(IEnumerable<SalaDto> salas, DateTime? fecha);

        Task<IEnumerable<DisertanteDto>> FiltrarDisertantesDisponibles(IEnumerable<DisertanteDto> disertantes, DateTime? fecha = null);

        Task<bool> ExistePorDisertanteYFecha(long disertanteId, DateTime fecha);
    }
}
