using System.ComponentModel;

namespace EM.Presentacion.MVC.Models
{
    public class ViewModelBase
    {
        public long Id { get; set; }

        [DisplayName("Eliminado")]
        public string EstaEliminado { get; set; }
    }
}
