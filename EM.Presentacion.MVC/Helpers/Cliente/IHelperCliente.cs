using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Cliente;

namespace EM.Presentacion.MVC.Helpers.Cliente
{
    public interface IHelperCliente
    {
        Task<bool> ExisteCliente(string dni);

        Task<bool> NuevoCliente(ClienteViewModel model);

        Task<ClienteViewModel> ObtenerClienteViewModelPorEmail(string email);

        Task<ClienteViewModel> ObtenerNombreCliente(long id);
    }
}
