namespace EM.IServicio.Factura
{
    using EM.ServicioBase.Dto;
    using ServicioBase.Servicio;
    using System.Threading.Tasks;

    public interface IFacturaServicio : IServicio
    {
        Task<long> InsertarDevuelveId(DtoBase dtoBase);
    }
}
