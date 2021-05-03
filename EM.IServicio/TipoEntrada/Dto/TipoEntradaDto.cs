namespace EM.IServicio.TipoEntrada.Dto
{
    using EM.ServicioBase.Dto;

    public class TipoEntradaDto : DtoBase
    {
        public string Nombre { get; set; }

        public long BeneficioEntradaId { get; set; }

        public long EmpresaId { get; set; }
    }
}
