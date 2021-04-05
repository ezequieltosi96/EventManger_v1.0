using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EM.Presentacion.MVC.Models.Localidad;

namespace EM.Presentacion.MVC.Models.Direccion
{
    public class DireccionViewModel : ViewModelBase
    {
        [DisplayName("Dirección")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Descripcion { get; set; }

        [DisplayName("Localidad")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long LocalidadId { get; set; }

        [DisplayName("Localidad")]
        public LocalidadViewModel Localidad { get; set; }
    }
}
