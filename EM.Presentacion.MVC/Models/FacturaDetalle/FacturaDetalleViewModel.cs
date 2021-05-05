using EM.Presentacion.MVC.Models.Entrada;
using EM.Presentacion.MVC.Models.Factura;
using System.ComponentModel;

namespace EM.Presentacion.MVC.Models.FacturaDetalle
{
    public class FacturaDetalleViewModel : ViewModelBase
    {
        public long FacturaId { get; set; }
        [DisplayName("Entrada")]
        public long EntradaId { get; set; }
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [DisplayName("Sub-Total")]
        public decimal SubTotal { get; set; }

        public FacturaViewModel Factura { get; set; }

        public EntradaViewModel Entrada { get; set; }
    }
}
