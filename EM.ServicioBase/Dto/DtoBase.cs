namespace EM.ServicioBase.Dto
{
    public class DtoBase
    {
        public long Id { get; set; }

        public bool EstaEliminado { get; set; }

        public string EliminadoStr => EstaEliminado ? "Si" : "No";
    }
}
