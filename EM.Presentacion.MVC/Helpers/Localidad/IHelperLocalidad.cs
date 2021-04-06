using System.Collections.Generic;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Localidad;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Localidad
{
    public interface IHelperLocalidad
    {
        Task<IEnumerable<SelectListItem>> ObtenerLocalidadesPorProvincia(long id);

        Task<long> ObtenerPaisIdPorLocalidad(long localidadId);

        Task<long> ObtenerProvinciaIdPorLocalidad(long localidadId);

    }
}
