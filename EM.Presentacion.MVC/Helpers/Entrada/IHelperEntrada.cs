using System.Collections.Generic;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Entrada;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Entrada
{
    public interface IHelperEntrada
    {
        Task<IEnumerable<SelectListItem>> PoblarComboGeneric(long eventoId);

        Task<EntradaViewModel> ObtenerEntrada(long id);
    }
}
