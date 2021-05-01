namespace EM.Dominio.Entidades
{
    using EM.DominioBase;
    public class Entrada : EntidadBase
    {
        public decimal Precio { get; set; }

        public long? ClienteId { get; set; }

        public long EventoId { get; set; }

        public long TipoEntradaId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual TipoEntrada TiposEntrada { get; set; }
    }
}
