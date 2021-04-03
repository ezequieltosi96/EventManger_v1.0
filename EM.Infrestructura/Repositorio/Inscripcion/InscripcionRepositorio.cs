namespace EM.Infrestructura.Repositorio.Inscripcion
{
    using EM.Dominio.Repositorio.Inscripcion;
    public class InscripcionRepositorio : Repositorio<Dominio.Entidades.Inscripcion>, IInscripcionRepositorio
    {
        public InscripcionRepositorio(DataContext context) : base(context)
        {
        }
    }
}
