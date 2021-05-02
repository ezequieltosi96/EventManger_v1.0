namespace EM.ServicioBase.Servicio
{
    using EM.ServicioBase.Dto;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IServicioConsulta
    {
        Task<DtoBase> Obtener(long id);

        Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true);
    }
}
