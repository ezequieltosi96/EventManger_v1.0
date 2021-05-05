using EM.Presentacion.MVC.Helpers.CustomValidators;
using EM.Presentacion.MVC.Models.Actividad;
using EM.Presentacion.MVC.Models.Empresa;
using EM.Presentacion.MVC.Models.Establecimiento;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EM.Presentacion.MVC.Models.Evento
{
    public class EventoViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(200, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(250, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El campo {0} solo admite numeros.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "El campo {0} debe ser mayor a {1}.")]
        public int Cupo { get; set; }

        [DisplayName("Cupo Disponible")]
        public int CupoDisponible { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [DateGreaterThanOrEqualToToday] // implementacion de una validacion personalizada -> ./Helpers/CustomValidations
        public DateTime Fecha { get; set; }

        [DisplayName("Empresa")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long EmpresaId { get; set; }

        [DisplayName("Establecimiento")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public long EstablecimientoId { get; set; }

        public IEnumerable<ActividadViewModel> Actividades { get; set; }

        public EmpresaViewModel Empresa { get; set; }

        public EstablecimientoViewModel Establecimiento { get; set; }

        // combos

        public IEnumerable<SelectListItem> Empresas { get; set; }

        public IEnumerable<SelectListItem> Establecimientos { get; set; }
    }
}
