namespace EM.Infrestructura.Repositorio.Localidad
{
    using EM.Dominio.Repositorio.Localidad;

    public class LocalidadRepositorio : Repositorio<Dominio.Entidades.Localidad>, ILocalidadRepositorio
    {
        public LocalidadRepositorio(DataContext context) : base(context)
        {
        }
    }
}
