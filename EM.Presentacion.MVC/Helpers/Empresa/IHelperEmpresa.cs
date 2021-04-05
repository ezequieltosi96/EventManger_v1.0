using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Empresa;

namespace EM.Presentacion.MVC.Helpers.Empresa
{
    public interface IHelperEmpresa
    {
        Task<bool> ExisteEmpresa(string cuil, string razonSocial);

        Task<bool> NuevaEmpresa(EmpresaViewModel model);
    }
}
