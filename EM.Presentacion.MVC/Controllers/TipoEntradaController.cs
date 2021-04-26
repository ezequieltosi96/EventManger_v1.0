using EM.IServicio.TipoEntrada;
using EM.IServicio.TipoEntrada.Dto;
using EM.Presentacion.MVC.Helpers.BeneficioEntrada;
using EM.Presentacion.MVC.Models.TipoEntrada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Controllers
{
    public class TipoEntradaController : Controller
    {
        private readonly ITipoEntradaServicio _tipoEntradaServicio;
        private readonly IHelperBeneficioEntrada _helperBeneficioEntrada;
        public TipoEntradaController(ITipoEntradaServicio tipoEntradaServicio, IHelperBeneficioEntrada helperBeneficioEntrada)
        {
            _tipoEntradaServicio = tipoEntradaServicio;
            _helperBeneficioEntrada = helperBeneficioEntrada;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";

            var dtos = (IEnumerable<TipoEntradaDto>)await _tipoEntradaServicio.Obtener(cadenaBuscar, mostrarTodos);

            var models = dtos.Select(b => new TipoEntradaViewModel()
            {
                Id = b.Id,
                EstaEliminado = b.EliminadoStr,
                Nombre = b.Nombre,
                BeneficioEntradaId = b.BeneficioEntradaId               
            }).ToList();
            foreach (var model in models)
            {
                model.BeneficioEntradaNombre = await _helperBeneficioEntrada.ObtenerNombreBeneficioEntrada(model.BeneficioEntradaId);
            }
            ViewBag.MostrarTodos = mostrarTodos;
            ViewBag.CadenaBuscar = cadenaBuscar;

            return View(models);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(long id)
        {
            try
            {
                var dto = (TipoEntradaDto)await _tipoEntradaServicio.Obtener(id);

                var vm = new TipoEntradaViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
                    BeneficioEntradaId = dto.BeneficioEntradaId,
                    BeneficioEntradaNombre = await _helperBeneficioEntrada.ObtenerNombreBeneficioEntrada(dto.BeneficioEntradaId),
                };

                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var beneficiosEntrada = await _helperBeneficioEntrada.PoblarSelect();

            return View(new TipoEntradaViewModel()
            {
                BeneficiosEntrada = beneficiosEntrada
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoEntradaViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var tipoEntradaDto = new TipoEntradaDto()
                {
                    Nombre = vm.Nombre,
                    BeneficioEntradaId = vm.BeneficioEntradaId
                };

                await _tipoEntradaServicio.Insertar(tipoEntradaDto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                var dto = (TipoEntradaDto)await _tipoEntradaServicio.Obtener(id);

                var vm = new TipoEntradaViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
                    BeneficioEntradaId = dto.BeneficioEntradaId,
                    BeneficioEntradaNombre = await _helperBeneficioEntrada.ObtenerNombreBeneficioEntrada(dto.BeneficioEntradaId),
                };

                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TipoEntradaViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var tipoEntradaDto = new TipoEntradaDto()
                {
                    Id = vm.Id,
                    Nombre = vm.Nombre,
                    BeneficioEntradaId = vm.BeneficioEntradaId
                };

                await _tipoEntradaServicio.Modificar(tipoEntradaDto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _tipoEntradaServicio.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
