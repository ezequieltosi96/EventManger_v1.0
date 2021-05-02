using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Pais
{
    public interface IHelperPais
    {
        Task<IEnumerable<SelectListItem>> PoblarSelect();

        Task<string> ObtenerNombrePais(long id);
    }
}
