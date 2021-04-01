namespace EM.Dominio.Entidades
{
    using EM.DominioBase;

    public class Localidad : EntidadBase
    {
        public string Nombre { get; set; }

        public long ProvinciaId { get; set; }
    }
}
