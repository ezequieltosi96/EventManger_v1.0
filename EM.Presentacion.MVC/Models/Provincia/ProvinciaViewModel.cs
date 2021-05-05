using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Provincia
{
    public class ProvinciaViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El campo {0} solo puede contener letras (a-z,A-Z).")]
        public string Nombre { get; set; }

        [DisplayName("País")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long PaisId { get; set; }

        [DisplayName("Paí   s")]
        public string PaisNombre { get; set; }

        public IEnumerable<SelectListItem> Paises { get; set; }
    }
}
