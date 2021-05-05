using System.ComponentModel;

namespace EM.Presentacion.MVC.Models.FormaPago
{
    public class FormaPagoViewModel : ViewModelBase
    {
        [DisplayName("Forma de pago")]
        public string Nombre { get; set; }
    }
}
