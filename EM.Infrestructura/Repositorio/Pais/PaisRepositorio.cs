namespace EM.Infrestructura.Repositorio
{
    using Dominio.Entidades;
    using EM.Dominio.Repositorio.Pais;

    public class PaisRepositorio : Repositorio<Pais>, IPaisRepositorio
    {
        public PaisRepositorio(DataContext context) : base(context)
        {
        }
    }
}
