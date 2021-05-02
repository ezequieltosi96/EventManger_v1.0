using EM.Presentacion.MVC.Models.Empresa;
using EM.Presentacion.MVC.Models.Persona;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Disertante
{
    public class DisertanteViewModel : PersonaViewModel
    {
        [DisplayName("Empresa")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long EmpresaId { get; set; }

        public EmpresaViewModel Empresa { get; set; }

    }
}
