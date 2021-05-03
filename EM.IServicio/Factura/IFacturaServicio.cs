namespace EM.IServicio.Factura
{
    using EM.ServicioBase.Dto;
    using ServicioBase.Servicio;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFacturaServicio : IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorEmpresa(long empresaId, string cadenaBuscar = "", bool mostrarTodos = true);

        Task<long> InsertarDevuelveId(DtoBase dtoBase);
    }
}
