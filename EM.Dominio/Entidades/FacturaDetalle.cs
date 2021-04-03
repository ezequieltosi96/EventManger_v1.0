using EM.DominioBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Dominio.Entidades
{
    public class FacturaDetalle : EntidadBase
    {
        public long FacturaId { get; set; }

        public long EntradaId { get; set; }

        public int Cantidad { get; set; }

        public decimal SubTotal { get; set; }

        public virtual Factura Factura { get; set; }

        public virtual Entrada Entrada { get; set; }
    }
}
