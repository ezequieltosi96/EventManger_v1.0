namespace EM.Infrestructura.Repositorio.Disertante
{
    using EM.Dominio.Repositorio.Disertante;

    public class DisertanteRepositorio : Repositorio<Dominio.Entidades.Disertante>, IDisertanteRepositorio
    {
        public DisertanteRepositorio(DataContext context) : base(context)
        {
        }
    }
}
