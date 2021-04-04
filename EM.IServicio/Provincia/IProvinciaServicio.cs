using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.Provincia.Dto;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Provincia
{
    using ServicioBase.Servicio;

    public interface IProvinciaServicio : IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorPais(long id);
    }
}
