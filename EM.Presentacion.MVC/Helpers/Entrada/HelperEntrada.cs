using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Entrada;
using EM.IServicio.Entrada.Dto;
using EM.Presentacion.MVC.Helpers.TipoEntrada;
using EM.Presentacion.MVC.Models.Entrada;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Entrada
{
    public class HelperEntrada : IHelperEntrada
    {
        private readonly IEntradaServicio _entradaServicio;
        private readonly IHelperTipoEntrada _helperTipoEntrada;

        public HelperEntrada(IEntradaServicio entradaServicio, IHelperTipoEntrada helperTipoEntrada)
        {
            _entradaServicio = entradaServicio;
            _helperTipoEntrada = helperTipoEntrada;
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
    }
}
