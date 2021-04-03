namespace EM.Dominio.Entidades
{
    using System;
    using EM.DominioBase;

    public class Actividad : EntidadBase
    {
        public string Nombre { get; set; }

        public DateTime FechaHora { get; set; }

        public long DisertanteId { get; set; }

        public long SalaId { get; set; }

        public long EventoId { get; set; }

        public Evento Evento { get; set; }

        public virtual Disertante Disertante { get; set; }

        public virtual Sala Sala { get; set; }
    }
}
