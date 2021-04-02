namespace EM.Infrestructura.Repositorio.Establecimiento
{
    using EM.Dominio.Repositorio.Establecimiento;

    public class EstablecimientoRepositorio : Repositorio<Dominio.Entidades.Establecimiento>, IEstablecimientoRepositorio
    {
        public EstablecimientoRepositorio(DataContext context) : base(context)
        {
        }
    }
}
