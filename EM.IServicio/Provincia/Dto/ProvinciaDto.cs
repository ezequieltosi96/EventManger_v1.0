namespace EM.IServicio.Provincia.Dto
{
    using EM.ServicioBase.Dto;

    public class ProvinciaDto : DtoBase
    {
        public string Nombre { get; set; }

        public long PaisId { get; set; }
    }
}
