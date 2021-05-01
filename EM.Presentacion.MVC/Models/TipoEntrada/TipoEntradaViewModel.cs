using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EM.Presentacion.MVC.Models.BenefinicioEntrada;

namespace EM.Presentacion.MVC.Models.TipoEntrada
{
    public class TipoEntradaViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        public string Nombre { get; set; }

        [DisplayName("Beneficio Entrada")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long BeneficioEntradaId { get; set; }

        [DisplayName("Beneficio Entrada")]
        public string BeneficioEntradaNombre { get; set; }

        public IEnumerable<SelectListItem> BeneficiosEntrada { get; set; }
    }
}
