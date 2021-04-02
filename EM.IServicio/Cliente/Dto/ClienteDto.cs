namespace EM.IServicio.Cliente.Dto
{
    using EM.IServicio.Persona.Dto;

    public class ClienteDto : PersonaDto
    {
        public long UsuarioId { get; set; }
    }
}
