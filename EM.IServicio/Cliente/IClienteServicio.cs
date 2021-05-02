using EM.ServicioBase.Dto;
using System.Threading.Tasks;
using EM.IServicio.Cliente.Dto;

namespace EM.IServicio.Cliente
{
    public interface IClienteServicio : ServicioBase.Servicio.IServicio
    {
        Task<bool> ExisteClientePorDni(string dni);

        Task<DtoBase> ObtenerPorEmail(string email);
        Task<bool> ExisteClientePorDniEmail(string dni, string email);

        Task<long> InsertarDevuelveId(DtoBase dto);
    }
}
