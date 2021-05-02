namespace EM.Infrestructura.Repositorio.TipoEntrada
{
    using Dominio.Entidades;
    using EM.Dominio.Repositorio.TipoEntrada;

    public class TipoEntradaRepositorio : Repositorio<TipoEntrada>, ITipoEntradaRepositorio
    {
        public TipoEntradaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
