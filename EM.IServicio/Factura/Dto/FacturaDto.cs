namespace EM.IServicio.Factura.Dto
{
    using EM.Dominio.Enum;
    using EM.ServicioBase.Dto;
    public class FacturaDto : DtoBase
    {
        public long EmpresaId { get; set; }

        public long ClienteId { get; set; }

        public TipoFactura TipoFactura { get; set; }

        public decimal Total { get; set; }
    }
}
