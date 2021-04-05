using System.Collections.Generic;
using System.Threading.Tasks;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Disertante
{
    public interface IDisertanteServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorEmpresa(long empresaId, string cadenaBuscar, bool mostrarTodos);
    }
}
