namespace EM.IServicio.Actividad.Dto
{
    using EM.ServicioBase.Dto;
    using System;

    public class ActividadDto : DtoBase
    {
        public string Nombre { get; set; }

        public DateTime FechaHora { get; set; }

        public long DisertanteId { get; set; }

        public long SalaId { get; set; }

        public long EventoId { get; set; }
    }
}
