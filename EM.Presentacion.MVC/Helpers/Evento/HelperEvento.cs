using EM.IServicio.Evento;
using EM.IServicio.Evento.Dto;
using EM.Presentacion.MVC.Models.Evento;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Helpers.Empresa;
using EM.Presentacion.MVC.Helpers.Establecimiento;

namespace EM.Presentacion.MVC.Helpers.Evento
{
    public class HelperEvento : IHelperEvento
    {
        private readonly IEventoServicio _eventoServicio;
        private readonly IHelperEstablecimiento _helperEstablecimiento;
        private readonly IHelperEmpresa _helperEmpresa;

        public HelperEvento(IEventoServicio eventoServicio, IHelperEstablecimiento helperEstablecimiento, IHelperEmpresa helperEmpresa)
        {
            _eventoServicio = eventoServicio;
            _helperEstablecimiento = helperEstablecimiento;
            _helperEmpresa = helperEmpresa;
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
                EstablecimientoId = evento.EstablecimientoId,
                Establecimiento = await _helperEstablecimiento.ObtenerEstablecimiento(evento.EstablecimientoId),
                Empresa = await _helperEmpresa.ObtenerEmpresa(evento.EmpresaId)
            };

            return model;
        }

        public async Task ActualizarCupoDisponible(long eventoId, int cantidad)
        {
            await _eventoServicio.ActualizarCupoDisponible(eventoId, cantidad);
        }
    }
}
