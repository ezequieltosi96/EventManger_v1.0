using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Entrada
{
    public interface IHelperEntrada
    {
        Task<IEnumerable<SelectListItem>> PoblarComboGeneric(long eventoId);
    }
}
