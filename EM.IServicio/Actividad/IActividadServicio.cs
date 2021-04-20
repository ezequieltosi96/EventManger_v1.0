using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.Actividad.Dto;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Actividad
{
    public interface IActividadServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorSalaYFecha(long salaId, DateTime fecha, long? eventoId = null);

        Task<IEnumerable<DtoBase>> ObtenerPorDisertanteYFecha(long disertanteId, DateTime fecha);

        Task<bool> DisertanteEstaDisponible(long disertanteId, DateTime fecha);

        Task<bool> SalaEstaDisponible(long salaId, DateTime fecha);

        Task<bool> Existe(string nombre, long eventoId);
    }
}
