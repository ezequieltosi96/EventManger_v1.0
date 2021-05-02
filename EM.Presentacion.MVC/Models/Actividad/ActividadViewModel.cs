using EM.Presentacion.MVC.Models.Disertante;
using EM.Presentacion.MVC.Models.Evento;
using EM.Presentacion.MVC.Models.Sala;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Actividad
{
    public class ActividadViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(150, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        public string Nombre { get; set; }

        [DisplayName("Fecha y Hora")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public DateTime FechaHora { get; set; }

        [DisplayName("Disertante")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long DisertanteId { get; set; }

        [DisplayName("Sala")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long SalaId { get; set; }

        [DisplayName("Evento")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long EventoId { get; set; }

        public DisertanteViewModel Disertante { get; set; }

        public SalaViewModel Sala { get; set; }

        public EventoViewModel Evento { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        public IEnumerable<SelectListItem> Salas { get; set; }

        public IEnumerable<SelectListItem> Disertantes { get; set; }
    }
}
