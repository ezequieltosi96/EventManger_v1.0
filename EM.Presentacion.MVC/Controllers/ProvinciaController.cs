using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Provincia;
using EM.IServicio.Provincia.Dto;
using EM.Presentacion.MVC.Helpers.Pais;
using EM.Presentacion.MVC.Models.Provincia;

namespace EM.Presentacion.MVC.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IHelperPais _helperPais;

        public ProvinciaController(IProvinciaServicio provinciaServicio, IHelperPais helperPais)
        {
            _provinciaServicio = provinciaServicio;
            _helperPais = helperPais;
        }

        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";

            var dtos = (IEnumerable<ProvinciaDto>)await _provinciaServicio.Obtener(cadenaBuscar, mostrarTodos);

            var models = dtos.Select(p => new ProvinciaViewModel()
            {
                Id = p.Id,
                EstaEliminado = p.EliminadoStr,
                Nombre = p.Nombre,
                PaisId = p.PaisId,
            }).ToList();

            foreach (var model in models)
            {
                model.PaisNombre = await _helperPais.ObtenerNombrePais(model.PaisId);
            }

            ViewBag.MostrarTodos = mostrarTodos;
            ViewBag.CadenaBuscar = cadenaBuscar;

            return View(models);
        }

        public async Task<IActionResult> Details(long id)
        {
            try
            {
                var dto = (ProvinciaDto)await _provinciaServicio.Obtener(id);

                var vm = new ProvinciaViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
                    PaisId = dto.PaisId,
                    PaisNombre = await _helperPais.ObtenerNombrePais(dto.PaisId),
                };

                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            var paises = await _helperPais.PoblarSelect();

            return View(new ProvinciaViewModel()
            {
                Paises = paises
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProvinciaViewModel vm)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var provinciaDto = new ProvinciaDto()
                {
                    Nombre = vm.Nombre,
                    PaisId = vm.PaisId
                };

                await _provinciaServicio.Insertar(provinciaDto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                var dto = (ProvinciaDto)await _provinciaServicio.Obtener(id);

                var vm = new ProvinciaViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
                    PaisId = dto.PaisId,
                    Paises = await _helperPais.PoblarSelect(),
                };

                return View(vm);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProvinciaViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado");
                }

                var provinciaDto = new ProvinciaDto()
                {
                    Id = vm.Id,
                    Nombre = vm.Nombre,
                    PaisId = vm.PaisId
                };

                await _provinciaServicio.Modificar(provinciaDto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _provinciaServicio.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
