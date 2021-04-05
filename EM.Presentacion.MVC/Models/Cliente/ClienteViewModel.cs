using System.ComponentModel.DataAnnotations;
using EM.Dominio.Identity;
using EM.Presentacion.MVC.Models.Persona;

namespace EM.Presentacion.MVC.Models.Cliente
{
    public class ClienteViewModel : PersonaViewModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "El campo {0} no es valido.")]
        public string Email { get; set; }
    }
}
