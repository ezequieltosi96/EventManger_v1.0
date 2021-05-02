using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.FormaPagoTarjeta;

namespace EM.Presentacion.MVC.Helpers.FormaPago.Tarjeta
{
    public interface IHelperFormaPagoTarjeta
    {
        Task<FormaPagoTarjetaViewModel> Obtener(long id);
    }
}
