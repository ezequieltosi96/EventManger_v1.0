using EM.Presentacion.MVC.Models.Factura;

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
