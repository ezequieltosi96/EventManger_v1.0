namespace EM.DominioBase
{
    using System.ComponentModel.DataAnnotations;
    public class EntidadBase
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public bool EstaEliminado { get; set; }
    }
}
