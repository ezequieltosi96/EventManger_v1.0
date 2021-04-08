using System.Collections.Generic;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Empresa;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Empresa
{
    public interface IHelperEmpresa
    {
        Task<bool> ExisteEmpresa(string cuil, string razonSocial);

        Task<bool> NuevaEmpresa(EmpresaViewModel model);

        Task<EmpresaViewModel> ObtenerEmpresaActual(string email);

        Task<EmpresaViewModel> ObtenerEmpresa(long id);

        Task<IEnumerable<SelectListItem>> PoblarCombo();
    }
}
