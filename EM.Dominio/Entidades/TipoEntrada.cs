namespace EM.Dominio.Entidades
{
    using EM.DominioBase;
    public class TipoEntrada : EntidadBase
    {
        public string Nombre { get; set; }

        public long BeneficioEntradaId { get; set; }

        public virtual BeneficioEntrada BeneficiosEntradas { get; set; }
    }
}
