using EM.Presentacion.MVC.Models.Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Models.FacturaDetalle
{
    public class FacturaDetalleViewModel : ViewModelBase
    {
        public long FacturaId { get; set; }

        public long EntradaId { get; set; }

        public int Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public FacturaViewModel Factura { get; set; }

        //public EntradaViewModel Entrada { get; set; }
    }
}
