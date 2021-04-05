using System.Threading.Tasks;

namespace EM.IServicio.Direccion
{
    public interface IDireccionServicio : ServicioBase.Servicio.IServicio
    {
        Task<long?> ExisteDireccion(long localidadId, string descripcion);
    }
}
