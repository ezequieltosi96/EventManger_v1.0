using EM.ServicioBase.Dto;
using System.Threading.Tasks;

namespace EM.IServicio.Cliente
{
    public interface IClienteServicio : ServicioBase.Servicio.IServicio
    {
        Task<bool> ExisteClientePorDni(string dni);

        Task<DtoBase> ObtenerPorEmail(string email);
    }
}
