using EM.Dominio.Enum;
using EM.Presentacion.MVC.Models.FormaPago;
using System.ComponentModel;

namespace EM.Presentacion.MVC.Models.FormaPagoTarjeta
{
    public class FormaPagoTarjetaViewModel : FormaPagoViewModel
    {
        [DisplayName("Número Tarjeta")]
        public string NumeroTarjeta { get; set; }
        [DisplayName("Mes")]
        public int MesExp { get; set; }
        [DisplayName("Año")]
        public int AnioExp { get; set; }
        [DisplayName("Código de seguridad")]
        public string CodigoSeguridad { get; set; }
        [DisplayName("Direccion de facturación")]
        public string DireccionFacturacion { get; set; }
        [DisplayName("Código postal")]
        public long CodigoPostal { get; set; }

    }
}
