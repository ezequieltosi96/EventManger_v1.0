
namespace EM.Dominio.Entidades
{
    using EM.DominioBase;
    public class Imagen : EntidadBase
    {
        public string Nombre { get; set; }

        public byte[] Data { get; set; }
    }
}
