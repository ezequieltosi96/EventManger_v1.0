namespace EM.Dominio.Entidades
{
    using EM.DominioBase;

    public class Sala : EntidadBase
    {
        public string Nombre { get; set; }

        public long EstablecimientoId { get; set; }

        public virtual Establecimiento Establecimiento { get; set; }
    }
}
