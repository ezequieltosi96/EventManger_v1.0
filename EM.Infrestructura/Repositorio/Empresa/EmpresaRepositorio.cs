namespace EM.Infrestructura.Repositorio.Empresa
{
    using EM.Dominio.Repositorio.Empresa;

    public class EmpresaRepositorio : Repositorio<Dominio.Entidades.Empresa>, IEmpresaRepositorio
    {
        public EmpresaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
