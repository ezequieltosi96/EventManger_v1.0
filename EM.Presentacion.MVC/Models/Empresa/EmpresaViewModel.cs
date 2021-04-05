using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Direccion;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Models.Empresa
{
    public class EmpresaViewModel : ViewModelBase
    {
        [DisplayName("Razon Social")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(200, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string RazonSocial { get; set; }

        [DisplayName("Nombre de Fantasia")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(200, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string NombreFantasia { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        public string Cuil { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "El campo {0} no es valido.")]
        public string Email { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long DireccionId { get; set; }

        [DisplayName("Dirección")]
        public string DireccionStr { get; set; }

        [DisplayName("Dirección")]
        public DireccionViewModel Direccion { get; set; }

        [DisplayName("Pais")]
        public long PaisId { get; set; }

        public long ProvinciaId { get; set; }

        public IEnumerable<SelectListItem> Paises { get; set; }

        public IEnumerable<SelectListItem> Provincias { get; set; }

        public IEnumerable<SelectListItem> Localidades { get; set; }
    }
}
