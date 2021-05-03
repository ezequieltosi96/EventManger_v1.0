using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Evento;
using EM.IServicio.Evento.Dto;
using EM.Presentacion.MVC.Models;
using EM.Presentacion.MVC.Models.Evento;
using EM.Presentacion.MVC.Models.Localidad;
using EM.Presentacion.MVC.Models.Pais;
using Microsoft.AspNetCore.Mvc;

namespace EM.Presentacion.MVC.ViewComponents
{
    public class CardsEventosViewComponent : ViewComponent
    {
        private readonly IEventoServicio _eventoServicio;

        public CardsEventosViewComponent(IEventoServicio eventoServicio)
        {
            _eventoServicio = eventoServicio;
        }

        public async Task<IViewComponentResult> InvokeAsync(string cadenaBuscar = "")
        {
            if (cadenaBuscar == null)
                cadenaBuscar = "";
            var dtos = (IEnumerable<EventoDto>)await _eventoServicio.ObtenerHome(cadenaBuscar);

            var models = dtos.Select(e => new EventoViewModel()
            {
                Id = e.Id,
                EstaEliminado = e.EliminadoStr,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Cupo = e.Cupo,
                EstablecimientoId = e.EstablecimientoId,
                EmpresaId = e.EmpresaId,
                Fecha = e.Fecha,
            }).ToList();

            return View(models);
        }
    }
}
