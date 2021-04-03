namespace EM.Dominio.Entidades
{
    using EM.DominioBase;
    public class Entrada : EntidadBase
    {
        public decimal Precio { get; set; }

        public long ClienteId { get; set; }

        public long EventoId { get; set; }

        public long TipoEntradaId { get; set; }

        public virtual Cliente Clientes { get; set; }

        public virtual Evento Eventos { get; set; }

        public virtual TipoEntrada TiposEntradas { get; set; }
    }
}
