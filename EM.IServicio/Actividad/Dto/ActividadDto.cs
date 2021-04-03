namespace EM.IServicio.Actividad.Dto
{
    using System;
    using EM.ServicioBase.Dto;

    public class ActividadDto : DtoBase
    {
        public string Nombre { get; set; }

        public DateTime FechaHora { get; set; }

        public long DisertanteId { get; set; }

        public long SalaId { get; set; }
    }
}
