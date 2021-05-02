using System.Threading.Tasks;

namespace EM.IServicio.Establecimiento
{
    public interface IEstablecimientoServicio : ServicioBase.Servicio.IServicio
    {
        Task<bool> Existe(string nombre, string direccionDescripcion, long direccionLocalidadId);

        Task<bool> Existe(string nombre, string direccionDescripcion, long direccionLocalidadId, long id);
    }
}
