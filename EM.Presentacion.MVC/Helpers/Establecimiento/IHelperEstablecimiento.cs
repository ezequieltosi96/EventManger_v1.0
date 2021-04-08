using System.Collections.Generic;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Establecimiento;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Establecimiento
{
    public interface IHelperEstablecimiento
    {
        Task<EstablecimientoViewModel> ObtenerEstablecimiento(long id);

        Task<IEnumerable<SelectListItem>> PoblarCombo();
    }
}
