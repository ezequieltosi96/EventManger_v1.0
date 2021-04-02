namespace EM.Dominio.Entidades
{
    using EM.DominioBase;
    public class Establecimiento : EntidadBase
    {
        public string Nombre { get; set; }

        public long DireccionId { get; set; }

        public virtual Direccion Direccion { get; set; }
    }
}
