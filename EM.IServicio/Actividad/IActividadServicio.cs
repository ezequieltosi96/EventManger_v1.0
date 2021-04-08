using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Actividad
{
    public interface IActividadServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorSalaYFecha(long salaId, DateTime fecha, long? eventoId = null);
    }
}
