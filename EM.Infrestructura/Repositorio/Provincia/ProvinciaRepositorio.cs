namespace EM.Infrestructura.Repositorio.Provincia
{
    using EM.Dominio.Repositorio.Provincia;
    using Dominio.Entidades;

    public class ProvinciaRepositorio : Repositorio<Provincia>, IProvinciaRepositorio
    {
        public ProvinciaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
