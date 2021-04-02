namespace EM.IServicio.Sala.Dto
{
    using EM.ServicioBase.Dto;

    public class SalaDto : DtoBase
    {
        public string Nombre { get; set; }

        public long EstablecimientoId { get; set; }
    }
}
