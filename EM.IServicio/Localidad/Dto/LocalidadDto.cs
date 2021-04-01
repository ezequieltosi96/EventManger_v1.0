namespace EM.IServicio.Localidad.Dto
{
    using EM.ServicioBase.Dto;

    public class LocalidadDto : DtoBase
    {
        public string Nombre { get; set; }

        public long ProvinciaId { get; set; }
    }
}
