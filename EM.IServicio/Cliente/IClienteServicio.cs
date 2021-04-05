using System.Threading.Tasks;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Cliente
{
    public interface IClienteServicio : ServicioBase.Servicio.IServicio
    {
        Task<bool> ExisteClientePorDni(string dni);

        Task<DtoBase> ObtenerPorEmail(string email);
    }
}
