namespace EM.IServicio.Inscripcion.Dto
{
    using EM.Dominio.Enum;
    using EM.ServicioBase.Dto;

    public class InscripcionDto : DtoBase
    {
        public EstadoInscripcion InscripcionEstado { get; set; }

        public long ClienteId { get; set; }

        public long EventoId { get; set; }

        public long EntradaId { get; set; }
    }
}
