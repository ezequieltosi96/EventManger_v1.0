using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Provincia
{
    public interface IHelperProvincia
    {
        Task<IEnumerable<SelectListItem>> PoblarSelect();

        Task<IEnumerable<SelectListItem>> ObtenerProvinciasPorPais(long id);

        Task<string> ObtenerNombreProvincia(long id);

        Task<long> ObtenerPaisId(long id);
    }
}
