namespace EM.IServicio.Establecimiento.Dto
{
    using EM.ServicioBase.Dto;

    public class EstablecimientoDto : DtoBase
    {
        public string Nombre { get; set; }

        public long DireccionId { get; set; }
    }
}
