namespace EM.ServicioBase.Servicio
{
    using EM.ServicioBase.Dto;
    using System.Threading.Tasks;

    public interface IServicioAbm
    {
        Task Insertar(DtoBase dtoBase);

        Task Modificar(DtoBase dtoBase);

        Task Eliminar(long id);
    }
}
