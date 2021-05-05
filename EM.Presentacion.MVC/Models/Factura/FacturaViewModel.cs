using EM.Dominio.Enum;
using EM.Presentacion.MVC.Models.Cliente;
using EM.Presentacion.MVC.Models.Empresa;
using EM.Presentacion.MVC.Models.FacturaDetalle;
using EM.Presentacion.MVC.Models.FormaPago;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Factura
{
    public class FacturaViewModel : ViewModelBase
    {
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Display(Name = "Empresa")]
        public long EmpresaId { get; set; }
        [Display(Name = "Empresa")]
        public string EmpresaNombre { get; set; }
        [Display(Name = "Cliente")]
        public long ClienteId { get; set; }
        [Display(Name = "Cliente")]
        public string ClienteNombre { get; set; }
        [Display(Name = "Forma de pago")]
        public long FormaPagoId { get; set; }
        [Display(Name = "Forma de pago")]
        public string FormaPagoNombre { get; set; }
        [Display(Name = "Tipo Factura")]
        public TipoFactura TipoFactura { get; set; }
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public EmpresaViewModel Empresa { get; set; }

        public FormaPagoViewModel FormaPago { get; set; }

        public IEnumerable<FacturaDetalleViewModel> FacturaDetalles { get; set; }

        [DisplayName("Evento")]
        public string EventoNombre { get; set; }
        [DisplayName("Entrada")]
        public long EntradaId { get; set; }
    }
}
