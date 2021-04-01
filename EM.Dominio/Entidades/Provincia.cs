using EM.DominioBase;

namespace EM.Dominio.Entidades
{
    public class Provincia : EntidadBase
    {
        public string Nombre { get; set; }

        public long PaisId { get; set; }

        public virtual Pais Pais { get; set; }
    }
}
