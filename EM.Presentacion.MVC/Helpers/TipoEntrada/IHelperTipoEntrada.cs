using EM.Presentacion.MVC.Models.TipoEntrada;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.TipoEntrada
{
    public interface IHelperTipoEntrada
    {
        Task<IEnumerable<SelectListItem>> PoblarSelect(long empresaId);

        Task<TipoEntradaViewModel> Obtener(long tipoEntradaId);
    }
}
