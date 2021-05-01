namespace EM.Infrestructura.Repositorio.Factura
{
    using Dominio.Entidades;
    using EM.Dominio.Repositorio.Factura;

    public class FacturaRepositorio : Repositorio<Factura>, IFacturaRepositorio
    {
        public FacturaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
