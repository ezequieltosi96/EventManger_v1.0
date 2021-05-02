using System.Threading.Tasks;
using EM.IServicio.FormaPagoTarjeta.Dto;
using EM.ServicioBase.Dto;

namespace EM.IServicio.FormaPagoTarjeta
{
    public interface IFormaPagoTarjetaServicio : ServicioBase.Servicio.IServicio
    {
        Task<long> InsertarDevuelveId(DtoBase dto);
    }
}
