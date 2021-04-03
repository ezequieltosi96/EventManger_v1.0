namespace EM.Infrestructura.Repositorio.FormaPago
{
    using EM.Dominio.Repositorio.FormaPago;
    public class FormaPagoRepositorio : Repositorio<Dominio.Entidades.FormaPago>, IFormaPagoRepositorio
    {
        public FormaPagoRepositorio(DataContext context) : base(context)
        {
        }
    }
}
