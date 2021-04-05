using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.Localidad.Dto;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Localidad
{
    public interface ILocalidadServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorProvincia(long id);
    }
}
