namespace EM.IServicio.FacturaDetalle.Dto
{
    using EM.ServicioBase.Dto;
    public class FacturaDetalleDto : DtoBase
    {
        public long FacturaId { get; set; }

        public long EntradaId { get; set; }

        public int Cantidad { get; set; }

        public decimal SubTotal { get; set; }
    }
}
