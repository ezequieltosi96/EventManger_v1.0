using EM.ServicioBase.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.IServicio.Entrada
{
    public interface IEntradaServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerGenericByEvento(long eventoId, bool mostrarTodos = true);

        Task<IEnumerable<DtoBase>> ObtenerByEvento(long eventoId, bool mostrarTodos = true);
    }
}
