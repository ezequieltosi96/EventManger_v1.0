using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.TipoEntrada.Dto;
using EM.ServicioBase.Dto;

namespace EM.IServicio.TipoEntrada
{
    using ServicioBase.Servicio;
    public interface ITipoEntradaServicio : IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorEmpresa(long empresaId, string cadenaBuscar = null, bool mostrarTodos = true);
    }
}
