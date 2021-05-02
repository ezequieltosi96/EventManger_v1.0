using EM.Dominio.Enum;
using EM.Presentacion.MVC.Models.Cliente;
using EM.Presentacion.MVC.Models.Empresa;
using EM.Presentacion.MVC.Models.FacturaDetalle;
using EM.Presentacion.MVC.Models.FormaPago;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Factura
{
    public class FacturaViewModel : ViewModelBase
    {
        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public long EmpresaId { get; set; }

        public string EmpresaNombre { get; set; }

        public long ClienteId { get; set; }

        public string ClienteNombre { get; set; }

        public long FormaPagoId { get; set; }

        public string FormaPagoNombre { get; set; }

        public TipoFactura TipoFactura { get; set; }

        public decimal Total { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public EmpresaViewModel Empresa { get; set; }

        public FormaPagoViewModel FormaPago { get; set; }

        public IEnumerable<FacturaDetalleViewModel> FacturaDetalles { get; set; }


    }
}
