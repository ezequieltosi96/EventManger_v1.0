using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EM.Infrestructura.Repositorio.Evento
{
    using EM.Dominio.Repositorio.Evento;

    public class EventoRepositorio : Repositorio<Dominio.Entidades.Evento>, IEventoRepositorio
    {
        public EventoRepositorio(DataContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Dominio.Entidades.Evento>> ObtenerEventosConEntradas(string cadenaBuscar = "")
        {
            var query = (from evento in _context.Eventos
                         join entrada in _context.Entradas on evento.Id equals entrada.EventoId
                         where !evento.EstaEliminado && evento.Fecha.Date > DateTime.Now && evento.Nombre.Contains(cadenaBuscar)
                         orderby evento.Fecha, evento.Nombre
                         select evento).Include(e => e.Actividades).Distinct();

            var eventos = await query.ToListAsync();

            return eventos;
        }
    }
}
