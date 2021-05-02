using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.BeneficioEntrada
{
    public interface IHelperBeneficioEntrada
    {
        Task<IEnumerable<SelectListItem>> PoblarSelect();

        Task<string> ObtenerNombreBeneficioEntrada(long id);
    }
}
