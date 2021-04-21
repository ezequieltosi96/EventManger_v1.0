using EM.IServicio.BeneficioEntrada;
using EM.IServicio.BeneficioEntrada.Dto;
using EM.Presentacion.MVC.Models.BenefinicioEntrada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Controllers
{
    public class BeneficioEntradaController : Controller
    {
        private readonly IBeneficioEntradaServicio _beneficioEntradaServicio;

        public BeneficioEntradaController(IBeneficioEntradaServicio beneficioEntradaServicio)
        {
            _beneficioEntradaServicio = beneficioEntradaServicio;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";

            var dtos = (IEnumerable<BeneficioEntradaDto>)await _beneficioEntradaServicio.Obtener(cadenaBuscar, mostrarTodos);

            var models = dtos.Select(d => new BeneficioEntradaViewModel()
            {
                Id = d.Id,
                EstaEliminado = d.EliminadoStr,
                Nombre = d.Nombre
            }).ToList();

            ViewBag.MostrarTodos = mostrarTodos;
            ViewBag.CadenaBuscar = cadenaBuscar;

            return View(models);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(long id)
        {
            try
            {
                var dto = (BeneficioEntradaDto)await _beneficioEntradaServicio.Obtener(id);

                var vm = new BeneficioEntradaViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
                };

                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeneficioEntradaViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var beneficioEntradaDto = new BeneficioEntradaDto()
                {
                    Nombre = vm.Nombre,
                };

                await _beneficioEntradaServicio.Insertar(beneficioEntradaDto);

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
                var dto = (BeneficioEntradaDto)await _beneficioEntradaServicio.Obtener(id);

                var vm = new BeneficioEntradaViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
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
        public async Task<IActionResult> Edit(BeneficioEntradaViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var beneficioEntradaDto = new BeneficioEntradaDto()
                {
                    Id = vm.Id,
                    Nombre = vm.Nombre,
                };

                await _beneficioEntradaServicio.Modificar(beneficioEntradaDto);

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
                await _beneficioEntradaServicio.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
