namespace EM.IServicio.Entrada.Dto
{
    using EM.ServicioBase.Dto;
    public class EntradaDto : DtoBase
    {
        public decimal Precio { get; set; }

        public long ClienteId { get; set; }

        public long EventoId { get; set; }

        public long TipoEntradaId { get; set; }
    }
}
