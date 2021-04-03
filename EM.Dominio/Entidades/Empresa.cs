namespace EM.Dominio.Entidades
{
    using EM.DominioBase;

    public class Empresa : EntidadBase
    {
        public string RazonSocial { get; set; }

        public string NombreFantasia { get; set; }

        public string Cuil { get; set; }

        public string Email { get; set; }

        public long DireccionId { get; set; }

        public virtual Direccion Direccion { get; set; }
    }
}
