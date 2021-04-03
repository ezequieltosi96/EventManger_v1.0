namespace EM.Infrestructura.Repositorio.FacturaDetalle
{
    using EM.Dominio.Repositorio.FacturaDetalle;
    public class FacturaDetalleRepositorio : Repositorio<Dominio.Entidades.FacturaDetalle>, IFacturaDetalleRepositorio
    {
        public FacturaDetalleRepositorio(DataContext context) : base(context)
        {
        }
    }
}
