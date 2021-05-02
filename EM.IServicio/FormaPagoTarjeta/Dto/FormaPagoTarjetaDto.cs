using EM.IServicio.FormaPago.Dto;

namespace EM.IServicio.FormaPagoTarjeta.Dto
{
    using EM.Dominio.Enum;
    using EM.ServicioBase.Dto;

    public class FormaPagoTarjetaDto : FormaPagoDto
    {
        public string NumeroTarjeta { get; set; }

        public int MesExp { get; set; }

        public int AnioExp { get; set; }

        public string CodigoSeguridad { get; set; }

        public string DireccionFacturacion { get; set; }
        public long CodigoPostal { get; set; }
    }
}
