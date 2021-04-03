namespace EM.Infrestructura.Repositorio.Sala
{
    using EM.Dominio.Repositorio.Sala;

    public class SalaRepositorio : Repositorio<Dominio.Entidades.Sala>, ISalaRespositorio
    {
        public SalaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
