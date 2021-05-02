using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Localidad
{
    public interface IHelperLocalidad
    {
        Task<IEnumerable<SelectListItem>> ObtenerLocalidadesPorProvincia(long id);

        Task<long> ObtenerPaisIdPorLocalidad(long localidadId);

        Task<long> ObtenerProvinciaIdPorLocalidad(long localidadId);

    }
}
