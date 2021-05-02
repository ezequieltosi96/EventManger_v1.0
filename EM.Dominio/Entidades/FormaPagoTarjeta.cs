namespace EM.Dominio.Entidades
{
    public class FormaPagoTarjeta : FormaPago
    {
        public string NumeroTarjeta { get; set; }

        public int MesExp { get; set; }

        public int AnioExp { get; set; }

        public string CodigoSeguridad { get; set; }

        public string DireccionFacturacion { get; set; }

        public long CodigoPostal { get; set; }

    }
}
