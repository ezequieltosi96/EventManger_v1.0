namespace EM.Infrestructura.Repositorio.FormaPagoTarjeta
{
    using EM.Dominio.Repositorio.FormaPagoTarjeta;
    public class FormaPagoTarjetaRepositorio : Repositorio<Dominio.Entidades.FormaPagoTarjeta>, IFormaPagoTarjetaRepositorio
    {
        public FormaPagoTarjetaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
