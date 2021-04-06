using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.Establecimiento.Dto;

namespace EM.IServicio.Establecimiento
{
    public interface IEstablecimientoServicio : ServicioBase.Servicio.IServicio
    {
        Task<bool> Existe(string nombre, string direccionDescripcion, long direccionLocalidadId);

        Task<bool> Existe(string nombre, string direccionDescripcion, long direccionLocalidadId, long id);
    }
}
