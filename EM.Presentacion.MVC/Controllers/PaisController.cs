using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Pais;
using EM.IServicio.Pais.Dto;
using EM.Presentacion.MVC.Models.Pais;
using Microsoft.AspNetCore.Authorization;

namespace EM.Presentacion.MVC.Controllers
{
    public class PaisController : Controller
    {
        private readonly IPaisServicio _paisServicio;

        public PaisController(IPaisServicio paisServicio)
        {
            _paisServicio = paisServicio;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";

            var dtos = (IEnumerable<PaisDto>)await _paisServicio.Obtener(cadenaBuscar, mostrarTodos);

            var models = dtos.Select(d => new PaisViewModel()
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
                var dto = (PaisDto)await _paisServicio.Obtener(id);

                var vm = new PaisViewModel()
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
        public async Task<IActionResult> Create(PaisViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var paisDto = new PaisDto()
                {
                    Nombre = vm.Nombre,
                };

                await _paisServicio.Insertar(paisDto);

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
                var dto = (PaisDto)await _paisServicio.Obtener(id);

                var vm = new PaisViewModel()
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
        public async Task<IActionResult> Edit(PaisViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var paisDto = new PaisDto()
                {
                    Id = vm.Id,
                    Nombre = vm.Nombre,
                };

                await _paisServicio.Modificar(paisDto);

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
                await _paisServicio.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
