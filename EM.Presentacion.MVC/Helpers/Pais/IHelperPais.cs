using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Pais
{
    public interface IHelperPais
    {
        Task<IEnumerable<SelectListItem>> PoblarSelect();

        Task<string> ObtenerNombrePais(long id);
    }
}
