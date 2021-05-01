using System.Collections.Generic;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.TipoEntrada;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.TipoEntrada
{
    public interface IHelperTipoEntrada
    {
        Task<IEnumerable<SelectListItem>> PoblarSelect();

        Task<TipoEntradaViewModel> Obtener(long tipoEntradaId);
    }
}
