using EM.Presentacion.MVC.Models.Establecimiento;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Establecimiento
{
    public interface IHelperEstablecimiento
    {
        Task<EstablecimientoViewModel> ObtenerEstablecimiento(long id);

        Task<IEnumerable<SelectListItem>> PoblarCombo();
    }
}
