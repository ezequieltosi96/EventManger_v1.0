using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Models.Identity
{
    public class UsuarioViewModel
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El campo {0} no es valido.")]
        public string Email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
