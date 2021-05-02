using EM.ServicioBase.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.IServicio.Sala
{
    public interface ISalaServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorEstablecimiento(long establecimientoId, string cadenaBuscar = "", bool mostrarTodos = true);
    }
}
