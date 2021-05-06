using System.ComponentModel;

namespace EM.Presentacion.MVC.Models.FormaPago
{
    public class FormaPagoViewModel : ViewModelBase
    {
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
    }
}
