namespace EM.IServicio.Disertante.Dto
{
    using EM.IServicio.Persona.Dto;

    public class DisertanteDto : PersonaDto
    {
        public long EmpresaId { get; set; }
    }
}
