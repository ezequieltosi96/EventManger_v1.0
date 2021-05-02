using EM.ServicioBase.Dto;
using System.Threading.Tasks;

namespace EM.IServicio.Empresa
{
    public interface IEmpresaServicio : ServicioBase.Servicio.IServicio
    {
        Task<DtoBase> ObtenerPorEmail(string email);
        Task<bool> Existe(string cuil, string razonSocial);
    }
}
