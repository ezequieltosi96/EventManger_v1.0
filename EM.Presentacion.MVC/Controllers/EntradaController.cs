using EM.IServicio.Entrada;
using EM.IServicio.Entrada.Dto;
using EM.Presentacion.MVC.Helpers.Cliente;
using EM.Presentacion.MVC.Helpers.Evento;
using EM.Presentacion.MVC.Helpers.TipoEntrada;
using EM.Presentacion.MVC.Models.Entrada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rotativa.AspNetCore;

namespace EM.Presentacion.MVC.Controllers
{
    public class EntradaController : Controller
    {
        private readonly IEntradaServicio _entradaServicio;
        private readonly IHelperTipoEntrada _helperTipoEntrada;
        private readonly IHelperEvento _helperEvento;
        private readonly IHelperCliente _helperCliente;

        public EntradaController(IEntradaServicio entradaServicio, IHelperTipoEntrada helperTipoEntrada, IHelperEvento helperEvento, IHelperCliente heleperCliente)
        {
            _entradaServicio = entradaServicio;
            _helperTipoEntrada = helperTipoEntrada;
            _helperEvento = helperEvento;
            _helperCliente = heleperCliente;
        }


        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> CreateGeneric(long eventoId, long empresaId)
        {
            ViewBag.EventoId = eventoId;
            ViewBag.EmpresaId = empresaId;

            var tipos = await _helperTipoEntrada.PoblarSelect(empresaId);
            // poblar el combo de tipo entrada
            var model = new EntradaViewModel()
            {
                EventoId = eventoId,
                TiposEntradas = tipos
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> CreateGeneric(EntradaViewModel vm, long empresaId)
        {
            try
            {
                ViewBag.EmpresaId = empresaId;
                ViewBag.EventoId = vm.EventoId;
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var entradaDto = new EntradaDto()
                {
                    EventoId = vm.EventoId,
                    ClienteId = null,
                    Precio = vm.Precio,
                    TipoEntradaId = vm.TipoEntradaId
                };

                await _entradaServicio.Insertar(entradaDto);

                return RedirectToAction("ListGeneric", new { eventoId = entradaDto.EventoId, empresaId });
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> ListGeneric(long eventoId, long empresaId, bool mostrarTodos = false)
        {
            var dtos = (IEnumerable<EntradaDto>)await _entradaServicio.ObtenerGenericByEvento(eventoId, mostrarTodos);

            var models = dtos.Select(e => new EntradaViewModel()
            {
                Id = e.Id,
                EstaEliminado = e.EliminadoStr,
                EventoId = e.EventoId,
                ClienteId = null,
                Precio = e.Precio,
                TipoEntradaId = e.TipoEntradaId,
            }).ToList();

            foreach (var vm in models)
            {
                vm.Evento = await _helperEvento.Obtener(vm.EventoId);
                vm.TipoEntrada = await _helperTipoEntrada.Obtener(vm.TipoEntradaId);
            }

            ViewBag.EventoId = eventoId;
            ViewBag.MostrarTodos = mostrarTodos;
            ViewBag.EmpresaId = empresaId;
            return View(models);
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> DeleteGeneric(long id, long eventoId, long empresaId)
        {
            try
            {
                await _entradaServicio.Eliminar(id);
                return RedirectToAction("ListGeneric", new { eventoId, empresaId });
            }
            catch (Exception)
            {
                return RedirectToAction("ListGeneric", new { eventoId, empresaId });
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> EditGeneric(long id, long eventoId, long empresaId)
        {
            var dto = (EntradaDto)await _entradaServicio.Obtener(id);

            if (dto == null) return RedirectToAction("ListGeneric", new { eventoId, empresaId });

            if (dto.ClienteId != null) return RedirectToAction("ListGeneric", new { eventoId, empresaId });

            var model = new EntradaViewModel()
            {
                Id = dto.Id,
                EstaEliminado = dto.EliminadoStr,
                EventoId = dto.EventoId,
                ClienteId = null,
                Precio = dto.Precio,
                TipoEntradaId = dto.TipoEntradaId,
                TiposEntradas = await _helperTipoEntrada.PoblarSelect(empresaId)
            };

            ViewBag.EmpresaId = empresaId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> EditGeneric(EntradaViewModel vm, long empresaId)
        {
            try
            {
                ViewBag.EmpresaId = empresaId;
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var entradaDto = new EntradaDto()
                {
                    Id = vm.Id,
                    EventoId = vm.EventoId,
                    ClienteId = null,
                    Precio = vm.Precio,
                    TipoEntradaId = vm.TipoEntradaId
                };

                await _entradaServicio.Modificar(entradaDto);

                return RedirectToAction("ListGeneric", new { eventoId = entradaDto.EventoId, empresaId });
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> List(long eventoId, bool mostrarTodos = false)
        {
            var dtos = (IEnumerable<EntradaDto>)await _entradaServicio.ObtenerByEvento(eventoId, mostrarTodos);

            var models = dtos.Select(e => new EntradaViewModel()
            {
                Id = e.Id,
                EstaEliminado = e.EliminadoStr,
                EventoId = e.EventoId,
                ClienteId = e.ClienteId.Value,
                Precio = e.Precio,
                TipoEntradaId = e.TipoEntradaId
            }).ToList();

            foreach (var vm in models)
            {
                vm.Evento = await _helperEvento.Obtener(vm.EventoId);
                vm.TipoEntrada = await _helperTipoEntrada.Obtener(vm.TipoEntradaId);
                vm.Cliente = await _helperCliente.Obtener(vm.ClienteId.Value);
            }

            ViewBag.EventoId = eventoId;
            ViewBag.MostrarTodos = mostrarTodos;
            return View(models);
        }


        public async Task<IActionResult> Details(long id, long eventoId)
        {
            try
            {
                var entrada = (EntradaDto)await _entradaServicio.Obtener(id);

                var model = new EntradaViewModel()
                {
                    Id = entrada.Id,
                    EstaEliminado = entrada.EliminadoStr,
                    EventoId = entrada.EventoId,
                    ClienteId = entrada.ClienteId.Value,
                    Precio = entrada.Precio,
                    TipoEntradaId = entrada.TipoEntradaId,
                    Evento = await _helperEvento.Obtener(entrada.EventoId),
                    Cliente = await _helperCliente.Obtener(entrada.ClienteId.Value),
                    TipoEntrada = await _helperTipoEntrada.Obtener(entrada.TipoEntradaId)
                };

                return new ViewAsPdf("PDF", model);
            }
            catch (Exception)
            {
                return RedirectToAction("List", new { eventoId });
            }
        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> ListClienteEntradas(long clienteId)
        {
            var entradas = (IEnumerable<EntradaDto>)await _entradaServicio.ObtenerByCliente(clienteId);

            var models = entradas.Select(e => new EntradaViewModel()
            {
                Id = e.Id,
                EstaEliminado = e.EliminadoStr,
                EventoId = e.EventoId,
                ClienteId = e.ClienteId.Value,
                Precio = e.Precio,
                TipoEntradaId = e.TipoEntradaId
            }).ToList();

            foreach (var vm in models)
            {
                vm.Evento = await _helperEvento.Obtener(vm.EventoId);
                vm.TipoEntrada = await _helperTipoEntrada.Obtener(vm.TipoEntradaId);
                vm.Cliente = await _helperCliente.Obtener(vm.ClienteId.Value);
            }

            return View(models);
        }
    }
}
