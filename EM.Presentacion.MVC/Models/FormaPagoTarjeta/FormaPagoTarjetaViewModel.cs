using EM.Dominio.Enum;
using EM.Presentacion.MVC.Models.FormaPago;

namespace EM.Presentacion.MVC.Models.FormaPagoTarjeta
{
    public class FormaPagoTarjetaViewModel : FormaPagoViewModel
    {
        public string NumeroTarjeta { get; set; }

        public int MesExp { get; set; }

        public int AnioExp { get; set; }

        public string CodigoSeguridad { get; set; }

        public string DireccionFacturacion { get; set; }

        public long CodigoPostal { get; set; }

    }
}
