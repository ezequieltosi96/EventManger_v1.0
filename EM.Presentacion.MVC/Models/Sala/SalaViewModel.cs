using EM.Presentacion.MVC.Models.Establecimiento;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Sala
{
    public class SalaViewModel : ViewModelBase
    {
        [DisplayName("Sala")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(200, ErrorMessage = "El campo {0} no debe permite mas de {1} caracteres.")]
        public string Nombre { get; set; }

        [DisplayName("Establecimiento")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long EstablecimientoId { get; set; }

        public EstablecimientoViewModel Establecimiento { get; set; }

        public IEnumerable<SelectListItem> Establecimientos { get; set; }

    }
}
