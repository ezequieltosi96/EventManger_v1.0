using System.Collections.Generic;
using EM.Presentacion.MVC.Models.Entrada;

namespace EM.Presentacion.MVC.Models.Factura
{
    public class FacturaConEntradasViewModel : ViewModelBase
    {
        public long FacturaId { get; set; }

        public List<EntradaViewModel> Entradas { get; set; }
    }
}
