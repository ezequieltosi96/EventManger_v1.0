namespace EM.Infrestructura.Repositorio
{
    using Dominio.Entidades;
    using EM.Dominio.Repositorio;

    public class PaisRepositorio : Repositorio<Pais>, IPaisRepositorio
    {
        public PaisRepositorio(DataContext context) : base(context)
        {
        }
    }
}
