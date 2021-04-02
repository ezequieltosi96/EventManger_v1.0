namespace EM.Infrestructura.Repositorio.Usuario
{
    using EM.Dominio.Repositorio.Usuario;

    public class UsuarioRepositorio : Repositorio<Dominio.Entidades.Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DataContext context) : base(context)
        {
        }
    }
}
