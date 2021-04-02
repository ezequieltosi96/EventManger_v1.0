namespace EM.Infrestructura.Repositorio.BeneficioEntrada
{
    using EM.Dominio.Repositorio.BeneficioEntrada;

    public class BeneficioEntradaRepositorio : Repositorio<Dominio.Entidades.BeneficioEntrada>, IBeneficioEntradaRepositorio
    {
        public BeneficioEntradaRepositorio(DataContext context) : base(context)
        {
        }
    }
}
