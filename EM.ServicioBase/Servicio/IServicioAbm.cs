namespace EM.ServicioBase.Servicio
{
    using System.Threading.Tasks;
    using EM.ServicioBase.Dto;

    public interface IServicioAbm
    {
        Task Insertar(DtoBase dtoBase);

        Task Modificar(DtoBase dtoBase);

        Task Eliminar(long id);
    }
}
