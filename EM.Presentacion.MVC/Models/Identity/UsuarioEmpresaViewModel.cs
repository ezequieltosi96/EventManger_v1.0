using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EM.Presentacion.MVC.Models.Empresa;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Models.Identity
{
    public class UsuarioEmpresaViewModel : ViewModelBase
    {
        public EmpresaViewModel Empresa { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Pais")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long PaisId { get; set; }

        [DisplayName("Provincia")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long ProvinciaId { get; set; }

        public IEnumerable<SelectListItem> Paises { get; set; }
    }
}
