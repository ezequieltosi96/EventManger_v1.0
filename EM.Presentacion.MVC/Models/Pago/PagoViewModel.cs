using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Cliente;
using EM.Presentacion.MVC.Models.FormaPagoTarjeta;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Models.Pago
{
    public class PagoViewModel
    {
        public ClienteViewModel Cliente { get; set; }

        public FormaPagoTarjetaViewModel FormaPago { get; set; }

        public long EntradaId { get; set; }

        public int Cantidad { get; set; }

        public IEnumerable<SelectListItem> EntradasGenericas { get; set; }
    }
}
