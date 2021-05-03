namespace EM.Dominio.Entidades
{
    using EM.DominioBase;
    public class TipoEntrada : EntidadBase
    {
        public string Nombre { get; set; }

        public long BeneficioEntradaId { get; set; }

        public long EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual BeneficioEntrada BeneficiosEntradas { get; set; }
    }
}
