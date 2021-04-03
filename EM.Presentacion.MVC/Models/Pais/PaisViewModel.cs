using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Pais
{
    public class PaisViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El campo {0} solo puede contener letras (a-z,A-Z).")]
        public string Nombre { get; set; }
    }
}
