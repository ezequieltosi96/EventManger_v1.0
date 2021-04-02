namespace EM.Infrestructura.Repositorio.Rol
{
    using EM.Dominio.Repositorio.Rol;

    public class RolRepositorio : Repositorio<Dominio.Entidades.Rol>, IRolRepositorio
    {
        public RolRepositorio(DataContext context) : base(context)
        {
        }
    }
}
