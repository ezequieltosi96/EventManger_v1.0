namespace EM.Infrestructura.Repositorio.TipoEntrada
{
    using EM.Dominio.Repositorio.TipoEntrada;
    using Dominio.Entidades;

    public class TipoEntradaRepositorio : Repositorio<TipoEntrada>, ITipoEntradaRepositorio
    {
        public TipoEntradaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
