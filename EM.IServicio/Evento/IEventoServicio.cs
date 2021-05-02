using EM.IServicio.Evento.Dto;
using EM.ServicioBase.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.IServicio.Evento
{
    public interface IEventoServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorEmpresa(long empresaId, string cadenaBuscar = "", bool mostrarTodos = true, bool mostrarPasados = true);

        Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true, bool mostrarPasados = true);

        Task<bool> Existe(EventoDto dto);

        Task ActualizarCupoDisponible(long eventoId, int cantidad);
    }
}
