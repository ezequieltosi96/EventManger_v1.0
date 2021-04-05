using System.Threading.Tasks;
using EM.ServicioBase.Dto;

namespace EM.IServicio.Empresa
{
    public interface IEmpresaServicio : ServicioBase.Servicio.IServicio
    {
        Task<DtoBase> ObtenerPorEmail(string email);
        Task<bool> Existe(string cuil, string razonSocial);
    }
}
