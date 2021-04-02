namespace EM.Dominio.Entidades
{
    public class Cliente : Persona
    {
        public long UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
