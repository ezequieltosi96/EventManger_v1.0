namespace EM.IServicio.Cliente.Dto
{
    using EM.IServicio.Persona.Dto;

    public class ClienteDto : PersonaDto
    {
        public string Email { get; set; }
    }
}
