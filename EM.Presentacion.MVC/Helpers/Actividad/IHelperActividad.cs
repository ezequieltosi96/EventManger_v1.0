using System;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Actividad
{
    public interface IHelperActividad
    {
        Task<bool> ExistePorSalaYFecha(long salaId, DateTime fecha, long? eventoId = null);
    }
}
