namespace EM.IServicio.Direccion.Dto
{
    using EM.ServicioBase.Dto;

    public class DireccionDto : DtoBase
    {
        public string Descripcion { get; set; }

        public long LocalidadId { get; set; }
    }
}
