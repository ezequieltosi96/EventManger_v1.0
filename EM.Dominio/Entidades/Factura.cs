namespace EM.Dominio.Entidades
{
    using EM.Dominio.Enum;
    using EM.DominioBase;
    using System;
    using System.Collections.Generic;

    public class Factura : EntidadBase
    {
        public DateTime Fecha { get; set; }

        public long EmpresaId { get; set; }

        public long ClienteId { get; set; }

        public long FormaPagoId { get; set; }

        public TipoFactura TipoFactura { get; set; }

        public decimal Total { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual FormaPago FormaPago { get; set; }

        public IEnumerable<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
