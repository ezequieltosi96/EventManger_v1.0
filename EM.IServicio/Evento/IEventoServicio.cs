using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.Evento.Dto;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Evento
{
    public interface IEventoServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorEmpresa(long empresaId, string cadenaBuscar = "", bool mostrarTodos = true, bool mostrarPasados = true);

        Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true, bool mostrarPasados = true);

        Task<bool> Existe(EventoDto dto);
    }
}
