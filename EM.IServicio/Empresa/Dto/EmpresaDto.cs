namespace EM.IServicio.Empresa.Dto
{
    using EM.ServicioBase.Dto;

    public class EmpresaDto : DtoBase
    {
        public string RazonSocial { get; set; }

        public string NombreFantasia { get; set; }

        public string Cuil { get; set; }

        public string Email { get; set; }

        public long DireccionId { get; set; }
    }
}
