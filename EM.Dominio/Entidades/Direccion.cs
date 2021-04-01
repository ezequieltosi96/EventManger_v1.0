namespace EM.Dominio.Entidades
{
    using EM.DominioBase;

    public class Direccion : EntidadBase
    {
        public string Descripcion { get; set; }

        public long LocalidadId { get; set; }

        public virtual Localidad Localidad { get; set; }
    }
}
