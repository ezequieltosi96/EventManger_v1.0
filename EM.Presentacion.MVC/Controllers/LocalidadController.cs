using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Localidad;
using EM.IServicio.Localidad.Dto;
using EM.Presentacion.MVC.Helpers.Pais;
using EM.Presentacion.MVC.Helpers.Provincia;
using EM.Presentacion.MVC.Models.Localidad;

namespace EM.Presentacion.MVC.Controllers
{
    public class LocalidadController : Controller
    {
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IHelperProvincia _helperProvincia;
        private readonly IHelperPais _helperPais;

        public LocalidadController(ILocalidadServicio localidadServicio, IHelperProvincia helperProvincia, IHelperPais helperPais)
        {
            _localidadServicio = localidadServicio;
            _helperProvincia = helperProvincia;
            _helperPais = helperPais;
        }

        public async Task<IActionResult> Index(bool mostrarTodos = false)
        {
            var dtos = (IEnumerable<LocalidadDto>)await _localidadServicio.Obtener(String.Empty, mostrarTodos);

            var models = dtos.Select(l => new LocalidadViewModel()
            {
                Id = l.Id,
                EstaEliminado = l.EliminadoStr,
                Nombre = l.Nombre,
                ProvinciaId = l.ProvinciaId
            }).ToList();

            foreach (var model in models)
            {
                model.ProvinciaNombre = await _helperProvincia.ObtenerNombreProvincia(model.ProvinciaId);
            }

            ViewBag.MostrarTodos = mostrarTodos;

            return View(models);
        }

        public async Task<IActionResult> Details(long id)
        {
            try
            {
                var dto = (LocalidadDto)await _localidadServicio.Obtener(id);

                var vm = new LocalidadViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
                    ProvinciaId = dto.ProvinciaId,
                    ProvinciaNombre = await _helperProvincia.ObtenerNombreProvincia(dto.ProvinciaId)
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

            var vm = new LocalidadViewModel()
            {
                Paises = paises
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocalidadViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado");

                var localidadDto = new LocalidadDto()
                {
                    Id = vm.Id,
                    Nombre = vm.Nombre,
                    ProvinciaId = vm.ProvinciaId,
                };

                await _localidadServicio.Insertar(localidadDto);

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
                var dto = (LocalidadDto)await _localidadServicio.Obtener(id);

                var paisId = await _helperProvincia.ObtenerPaisId(dto.ProvinciaId);

                var vm = new LocalidadViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
                    ProvinciaId = dto.ProvinciaId,
                    PaisId = paisId,
                    Paises = await _helperPais.PoblarSelect(),
                    Provincias = await _helperProvincia.ObtenerProvinciasPorPais(paisId),
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
        public async Task<IActionResult> Edit(LocalidadViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado");

                var localidadDto = new LocalidadDto()
                {
                    Id = vm.Id,
                    Nombre = vm.Nombre,
                    ProvinciaId = vm.ProvinciaId,
                };

                await _localidadServicio.Modificar(localidadDto);

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
                await _localidadServicio.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<JsonResult> ObtenerProvinciasPorPais(long paisId)
        {
            var provincias = await _helperProvincia.ObtenerProvinciasPorPais(paisId);

            return Json(provincias);
        }
    }
}
