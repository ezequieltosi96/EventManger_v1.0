using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EM.Presentacion.MVC.Models.Cliente;

namespace EM.Presentacion.MVC.Models.Identity
{
    public class UsuarioClienteViewModel : ViewModelBase
    {
        public ClienteViewModel Cliente { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
