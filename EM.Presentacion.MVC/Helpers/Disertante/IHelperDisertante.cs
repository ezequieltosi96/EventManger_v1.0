using EM.Presentacion.MVC.Models.Disertante;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Disertante
{
    public interface IHelperDisertante
    {
        Task<DisertanteViewModel> ObtenerDisertante(long id);

        Task<IEnumerable<SelectListItem>> PoblarComboPorEmpresa(long empresaId, DateTime? fecha = null);
    }
}
