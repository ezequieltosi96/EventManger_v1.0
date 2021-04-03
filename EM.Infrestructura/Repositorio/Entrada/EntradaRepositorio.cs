namespace EM.Infrestructura.Repositorio.Entrada
{
    using EM.Dominio.Repositorio.Entrada;
    public class EntradaRepositorio : Repositorio<Dominio.Entidades.Entrada>, IEntradaRepositorio
    {
        public EntradaRepositorio(DataContext context) : base(context)
        {
        }
    }
}