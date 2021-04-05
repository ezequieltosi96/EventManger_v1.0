using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Localidad
{
    public interface IHelperLocalidad
    {
        Task<IEnumerable<SelectListItem>> ObtenerLocalidadesPorProvincia(long id);
    }
}
