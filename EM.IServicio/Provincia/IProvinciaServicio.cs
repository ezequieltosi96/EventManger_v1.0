using EM.ServicioBase.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.IServicio.Provincia
{
    using ServicioBase.Servicio;

    public interface IProvinciaServicio : IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorPais(long id);
    }
}
