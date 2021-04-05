using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Persona
{
    public class PersonaViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "El {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El campo {0} solo puede contener letras (a-z,A-Z).")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El campo {0} solo puede contener letras (a-z,A-Z).")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El {0} es requerido.")]
        [MaxLength(8, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(7, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "El {0} solo puede contener números.")]
        public string Dni { get; set; }

        [DisplayName("Nombre Completo")]
        public string ApyNom => $"{Apellido} {Nombre}";
    }
}
