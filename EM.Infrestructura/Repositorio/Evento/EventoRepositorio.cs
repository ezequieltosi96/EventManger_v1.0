namespace EM.Infrestructura.Repositorio.Evento
{
    using EM.Dominio.Repositorio.Evento;

    public class EventoRepositorio : Repositorio<Dominio.Entidades.Evento>, IEventoRepositorio
    {
        public EventoRepositorio(DataContext context) : base(context)
        {
        }
    }
}
