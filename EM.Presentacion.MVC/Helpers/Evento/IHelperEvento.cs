using EM.Presentacion.MVC.Models.Evento;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Evento
{
    public interface IHelperEvento
    {
        Task<EventoViewModel> Obtener(long eventoId);
    }
}
