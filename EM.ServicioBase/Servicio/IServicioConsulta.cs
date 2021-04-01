namespace EM.ServicioBase.Servicio
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EM.ServicioBase.Dto;

    public interface IServicioConsulta
    {
        Task<DtoBase> Obtener(long id);

        Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true);
    }
}
