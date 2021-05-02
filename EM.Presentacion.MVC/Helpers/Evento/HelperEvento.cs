﻿using EM.IServicio.Evento;
using EM.IServicio.Evento.Dto;
using EM.Presentacion.MVC.Models.Evento;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Evento
{
    public class HelperEvento : IHelperEvento
    {
        private readonly IEventoServicio _eventoServicio;

        public HelperEvento(IEventoServicio eventoServicio)
        {
            _eventoServicio = eventoServicio;
        }

        public async Task<EventoViewModel> Obtener(long eventoId)
        {
            var evento = (EventoDto)await _eventoServicio.Obtener(eventoId);

            var model = new EventoViewModel()
            {
                Id = evento.Id,
                EstaEliminado = evento.EliminadoStr,
                Cupo = evento.Cupo,
                CupoDisponible = evento.CupoDisponible,
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                Fecha = evento.Fecha,
                EmpresaId = evento.EmpresaId,
                EstablecimientoId = evento.EstablecimientoId
            };

            return model;
        }
    }
}