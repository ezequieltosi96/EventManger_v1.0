namespace EM.Dominio.Entidades
{
    public class Disertante : Persona
    {
        public long EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
