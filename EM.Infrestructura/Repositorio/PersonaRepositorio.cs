namespace EM.Infrestructura.Repositorio
{
    using EM.Dominio.Entidades;
    using EM.Dominio.Repositorio.Persona;

    public class PersonaRepositorio : Repositorio<Persona>, IPersonaRepositorio
    {
        public PersonaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
