namespace EM.IServicio.FormaPagoTarjeta.Dto
{
    using EM.Dominio.Enum;
    using EM.ServicioBase.Dto;
    public class FormaPagoTarjetaDto : DtoBase
    {
        public TipoTarjeta TipoTarjeta { get; set; }

        public string NumeroTarjeta { get; set; }

        public int MesExp { get; set; }

        public int AnioExp { get; set; }

        public string CodigoSeguridad { get; set; }

        public string DireccionFacturacion { get; set; }

        public string DireccionFacturacion2 { get; set; }

        public long PaisId { get; set; }

        public long CodigoPostal { get; set; }

        public int NumeroPagos { get; set; }

        public decimal SubTotalCuota { get; set; }
    }
}
