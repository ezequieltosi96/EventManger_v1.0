namespace EM.Infrestructura.Repositorio.Direccion
{
    using EM.Dominio.Repositorio.Direccion;

    public class DireccionRepositorio : Repositorio<Dominio.Entidades.Direccion>, IDireccionRepositorio
    {
        public DireccionRepositorio(DataContext context) : base(context)
        {
        }
    }
}
