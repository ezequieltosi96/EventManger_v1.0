

namespace EM.Dominio.Entidades
{
    using EM.Dominio.Enum;
    using EM.DominioBase;
    public class Inscripcion : EntidadBase
    {
        public long ClienteId { get; set; }

        public long EventoId { get; set; }

        public long EntradaId { get; set; }

        public EstadoInscripcion InscripcionEstado { get; set; }

        public virtual Cliente Clientes { get; set; }

        public virtual Evento Eventos { get; set; }

        public virtual Entrada Entradas { get; set; }
    }
}
