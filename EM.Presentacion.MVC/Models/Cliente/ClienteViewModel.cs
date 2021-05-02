using EM.Presentacion.MVC.Models.Persona;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Cliente
{
    public class ClienteViewModel : PersonaViewModel
    {
        [DataType(DataType.EmailAddress, ErrorMessage = "El campo {0} no es valido.")]
        public string Email { get; set; }
    }
}
