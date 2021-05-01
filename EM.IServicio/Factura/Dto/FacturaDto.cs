namespace EM.IServicio.Factura.Dto
{
    using EM.Dominio.Enum;
    using EM.IServicio.FacturaDetalle.Dto;
    using EM.ServicioBase.Dto;
    using System;
    using System.Collections.Generic;

    public class FacturaDto : DtoBase
    {
        public DateTime Fecha { get; set; }

        public long EmpresaId { get; set; }

        public long ClienteId { get; set; }

        public long FormaPagoId { get; set; }

        public TipoFactura TipoFactura { get; set; }

        public decimal Total { get; set; }

        public IEnumerable<FacturaDetalleDto> FacturaDetalles { get; set; }
    }
}
