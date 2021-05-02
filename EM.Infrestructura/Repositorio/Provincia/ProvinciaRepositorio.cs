namespace EM.Infrestructura.Repositorio.Provincia
{
    using Dominio.Entidades;
    using EM.Dominio.Repositorio.Provincia;

    public class ProvinciaRepositorio : Repositorio<Provincia>, IProvinciaRepositorio
    {
        public ProvinciaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
