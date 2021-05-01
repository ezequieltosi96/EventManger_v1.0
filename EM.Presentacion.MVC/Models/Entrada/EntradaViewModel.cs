using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Cliente;
using EM.Presentacion.MVC.Models.Evento;
using EM.Presentacion.MVC.Models.TipoEntrada;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Models.Entrada
{
    public class EntradaViewModel : ViewModelBase
    {

        [DisplayName("Precio")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public decimal Precio { get; set; }

        [DisplayName("Cliente")]
        public long? ClienteId { get; set; }

        [DisplayName("Evento")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long EventoId { get; set; }

        [DisplayName("Tipo de Entrada")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long TipoEntradaId { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public EventoViewModel Evento { get; set; }

        public TipoEntradaViewModel TipoEntrada { get; set; }

        public IEnumerable<SelectListItem> TiposEntradas { get; set; }
    }
}
