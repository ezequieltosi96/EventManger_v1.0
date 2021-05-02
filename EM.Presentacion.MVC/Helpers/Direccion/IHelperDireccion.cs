using EM.Presentacion.MVC.Models.Direccion;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Direccion
{
    public interface IHelperDireccion
    {
        Task<long?> ExisteDireccion(DireccionViewModel model);

        Task<long> NuevaDireccion(DireccionViewModel model);

        Task<DireccionViewModel> ObtenerDireccion(long id);

    }
}
