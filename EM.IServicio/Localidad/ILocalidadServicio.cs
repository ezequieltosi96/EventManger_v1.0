using EM.ServicioBase.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.IServicio.Localidad
{
    public interface ILocalidadServicio : ServicioBase.Servicio.IServicio
    {
        Task<IEnumerable<DtoBase>> ObtenerPorProvincia(long id);
    }
}
