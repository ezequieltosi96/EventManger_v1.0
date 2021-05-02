using EM.Presentacion.MVC.Models.Direccion;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Establecimiento
{
    public class EstablecimientoViewModel : ViewModelBase
    {
        [DisplayName("Establecimiento")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(200, ErrorMessage = "El campo {0} no debe permite mas de {1} caracteres.")]
        public string Nombre { get; set; }

        [DisplayName("Direccion")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long DireccionId { get; set; }

        [DisplayName("Direccion")]
        public DireccionViewModel Direccion { get; set; }

        [DisplayName("Pais")]
        public long PaisId { get; set; }

        public long ProvinciaId { get; set; }

        public IEnumerable<SelectListItem> Paises { get; set; }

        public IEnumerable<SelectListItem> Provincias { get; set; }

        public IEnumerable<SelectListItem> Localidades { get; set; }
    }
}
