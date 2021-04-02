namespace EM.Infrestructura.Repositorio.Cliente
{
    using EM.Dominio.Repositorio.Cliente;

    public class ClienteRepositorio : Repositorio<Dominio.Entidades.Cliente>, IClienteRepositorio
    {
        public ClienteRepositorio(DataContext context) : base(context)
        {
        }
    }
}
