using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Entrada;
using EM.IServicio.Entrada.Dto;
using EM.Presentacion.MVC.Helpers.Cliente;
using EM.Presentacion.MVC.Helpers.Evento;
using EM.Presentacion.MVC.Helpers.TipoEntrada;
using EM.Presentacion.MVC.Models.Entrada;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Entrada
{
    public class HelperEntrada : IHelperEntrada
    {
        private readonly IEntradaServicio _entradaServicio;
        private readonly IHelperTipoEntrada _helperTipoEntrada;
        private readonly IHelperEvento _helperEvento;
        private readonly IHelperCliente _helperCliente;

        public HelperEntrada(IEntradaServicio entradaServicio, IHelperTipoEntrada helperTipoEntrada, IHelperEvento helperEvento, IHelperCliente helperCliente)
        {
            _entradaServicio = entradaServicio;
            _helperTipoEntrada = helperTipoEntrada;
            _helperEvento = helperEvento;
            _helperCliente = helperCliente;
        }


        public async Task<IEnumerable<SelectListItem>> PoblarComboGeneric(long eventoId)
        {
            var entradas = (IEnumerable<EntradaDto>)await _entradaServicio.ObtenerGenericByEvento(eventoId);
            var models = entradas.Select(e => new EntradaViewModel()
            {
                Id = e.Id,
                TipoEntradaId = e.TipoEntradaId,
                Precio = e.Precio,
                EventoId = e.EventoId
            }).ToList();

            foreach (var entrada in models)
            {
                entrada.TipoEntrada = await _helperTipoEntrada.Obtener(entrada.TipoEntradaId);
            }

            var combo = models.Select(e => new { Id = e.Id, Descripcion = $"{e.TipoEntrada.Nombre} - ${e.Precio}" }).ToList();

            return new SelectList(combo, "Id", "Descripcion");
        }

        public async Task<EntradaViewModel> ObtenerEntrada(long id)
        {
            var e = (EntradaDto)await _entradaServicio.Obtener(id);
            var model = new EntradaViewModel()
            {
                Id = e.Id,
                TipoEntradaId = e.TipoEntradaId,
                Precio = e.Precio,
                EventoId = e.EventoId,
                Evento = await _helperEvento.Obtener(e.EventoId),
                TipoEntrada = await _helperTipoEntrada.Obtener(e.TipoEntradaId),
                ClienteId = e.ClienteId
            };
            return model;
        }

        public async Task<EntradaViewModel> ObtenerEntradaConCliente(long id)
        {
            var e = (EntradaDto)await _entradaServicio.Obtener(id);
            var model = new EntradaViewModel()
            {
                Id = e.Id,
                TipoEntradaId = e.TipoEntradaId,
                Precio = e.Precio,
                EventoId = e.EventoId,
                Evento = await _helperEvento.Obtener(e.EventoId),
                TipoEntrada = await _helperTipoEntrada.Obtener(e.TipoEntradaId),
                ClienteId = e.ClienteId.Value,
                Cliente = await _helperCliente.Obtener(e.ClienteId.Value)
            };
            return model;
        }
    }
}
