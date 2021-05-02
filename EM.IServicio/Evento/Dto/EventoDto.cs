namespace EM.IServicio.Evento.Dto
{
    using EM.IServicio.Actividad.Dto;
    using EM.ServicioBase.Dto;
    using System;
    using System.Collections.Generic;

    public class EventoDto : DtoBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Cupo { get; set; }

        public int CupoDisponible { get; set; }

        public DateTime Fecha { get; set; }

        public long EstablecimientoId { get; set; }

        public long EmpresaId { get; set; }

        public IEnumerable<ActividadDto> Actividades { get; set; }
    }
}
