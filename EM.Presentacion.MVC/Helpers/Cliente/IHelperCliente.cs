using EM.Presentacion.MVC.Models.Cliente;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Cliente
{
    public interface IHelperCliente
    {
        Task<bool> ExisteCliente(string dni);

        Task<bool> ExisteCliente(string dni, string email);

        Task<bool> NuevoCliente(ClienteViewModel model);

        Task<ClienteViewModel> ObtenerClienteViewModelPorEmail(string email);

        Task<ClienteViewModel> Obtener(long clienteId);

        Task<ClienteViewModel> ObtenerNombreCliente(long id);
    }
}
