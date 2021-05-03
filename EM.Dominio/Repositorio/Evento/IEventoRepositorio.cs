using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Dominio.Repositorio.Evento
{
    public interface IEventoRepositorio : IRepositorio<Entidades.Evento>
    {
        Task<IEnumerable<Dominio.Entidades.Evento>> ObtenerEventosConEntradas(string cadenaBuscar = "");
    }
}
