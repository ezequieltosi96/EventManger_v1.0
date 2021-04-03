namespace EM.Infrestructura.Repositorio.Actividad
{
    using EM.Dominio.Repositorio.Actividad;

    public class ActividadRepositorio : Repositorio<Dominio.Entidades.Actividad>, IActividadRepositorio
    {
        public ActividadRepositorio(DataContext context) : base(context)
        {
        }
    }
}
