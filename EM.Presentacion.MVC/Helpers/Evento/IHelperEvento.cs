using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Evento;

namespace EM.Presentacion.MVC.Helpers.Evento
{
    public interface IHelperEvento
    {
        Task<EventoViewModel> Obtener(long eventoId);
    }
}
