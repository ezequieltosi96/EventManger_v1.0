using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Disertante;

namespace EM.Presentacion.MVC.Helpers.Disertante
{
    public interface IHelperDisertante
    {
        Task<DisertanteViewModel> ObtenerDisertante(long id);
    }
}
