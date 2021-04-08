using System;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Sala;

namespace EM.Presentacion.MVC.Helpers.Sala
{
    public interface IHelperSala
    {
        Task<SalaViewModel> ObtenerSala(long id);

        Task<bool> ExisteSalaDisponible(long establecimientoId, DateTime fecha, long? eventoId = null);
    }
}
