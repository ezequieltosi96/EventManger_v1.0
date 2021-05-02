using EM.Presentacion.MVC.Models.FormaPago;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.FormaPago
{
    public interface IHelperFormaPago
    {
        Task<FormaPagoViewModel> ObtenerFormaPago(long id);

        Task<IEnumerable<SelectListItem>> PoblarCombo();
    }
}
