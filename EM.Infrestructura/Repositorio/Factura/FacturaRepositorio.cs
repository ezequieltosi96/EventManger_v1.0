namespace EM.Infrestructura.Repositorio.Factura
{
    using EM.Dominio.Repositorio.Factura;
    public class FacturaRepositorio : Repositorio<Dominio.Entidades.Factura>, IFacturaRepositorio
    {
        public FacturaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
