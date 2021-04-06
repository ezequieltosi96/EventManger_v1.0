using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Establecimiento;
using EM.IServicio.Establecimiento.Dto;
using EM.Presentacion.MVC.Helpers.Direccion;
using EM.Presentacion.MVC.Helpers.Localidad;
using EM.Presentacion.MVC.Helpers.Pais;
using EM.Presentacion.MVC.Helpers.Provincia;
using EM.Presentacion.MVC.Models.Establecimiento;
using Microsoft.AspNetCore.Authorization;

namespace EM.Presentacion.MVC.Controllers
{
    public class EstablecimientoController : Controller
    {
        private readonly IEstablecimientoServicio _establecimientoServicio;
        private readonly IHelperDireccion _helperDireccion;
        private readonly IHelperLocalidad _helperLocalidad;
        private readonly IHelperProvincia _helperProvincia;
        private readonly IHelperPais _helperPais;

        public EstablecimientoController(IEstablecimientoServicio establecimientoServicio, IHelperDireccion helperDireccion, IHelperLocalidad helperLocalidad, IHelperProvincia helperProvincia, IHelperPais helperPais)
        {
            _establecimientoServicio = establecimientoServicio;
            _helperDireccion = helperDireccion;
            _helperLocalidad = helperLocalidad;
            _helperProvincia = helperProvincia;
            _helperPais = helperPais;
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";

            var establecimientos = (IEnumerable<EstablecimientoDto>)await _establecimientoServicio.Obtener(cadenaBuscar, mostrarTodos);

            var models = establecimientos.Select(e => new EstablecimientoViewModel()
            {
                Id = e.Id,
                DireccionId = e.DireccionId,
                EstaEliminado = e.EliminadoStr,
                Nombre = e.Nombre,
            }).ToList();

            foreach (var m in models)
            {
                m.Direccion = await _helperDireccion.ObtenerDireccion(m.DireccionId);
            }

            ViewBag.CadenaBuscar = cadenaBuscar;
            ViewBag.MostrarTodos = mostrarTodos;

            return View(models);
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Details(long id)
        {
            try
            {
                var dto = (EstablecimientoDto)await _establecimientoServicio.Obtener(id);

                var direccion = await _helperDireccion.ObtenerDireccion(dto.DireccionId);

                var model = new EstablecimientoViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    DireccionId = dto.DireccionId,
                    Nombre = dto.Nombre,
                    Direccion = direccion,
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Create()
        {
            var model = new EstablecimientoViewModel()
            {
                Paises = await _helperPais.PoblarSelect()
            };

            ViewBag.EstablecimientoDuplicado = false;

            return View(model);
        }

        [Authorize(Roles = "Admin, Empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstablecimientoViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado.");

                ViewBag.EstablecimientoDuplicado = false;
                // Existe establecimiento
                var existeEstablecimiento = await _establecimientoServicio.Existe(vm.Nombre, vm.Direccion.Descripcion, vm.Direccion.LocalidadId);
                if (existeEstablecimiento)
                {
                    ViewBag.EstablecimientoDuplicado = true;
                    throw new Exception("Establecimiento duplicado.");
                }
                // Existe direccion -> si no existe la creo y obtengo el id
                var direccionId = await _helperDireccion.ExisteDireccion(vm.Direccion);
                if (!direccionId.HasValue)
                {
                    // creo la direccion y devuelvo el id
                    direccionId = await _helperDireccion.NuevaDireccion(vm.Direccion);
                }
                vm.DireccionId = direccionId.Value;

                // creo el establecimiento
                var dto = new EstablecimientoDto()
                {
                    Nombre = vm.Nombre,
                    DireccionId = vm.DireccionId
                };

                await _establecimientoServicio.Insertar(dto);

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
                var dto = (EstablecimientoDto)await _establecimientoServicio.Obtener(id);

                var direccion = await _helperDireccion.ObtenerDireccion(dto.DireccionId);
                var provinciaId = await _helperLocalidad.ObtenerProvinciaIdPorLocalidad(direccion.LocalidadId);

                var model = new EstablecimientoViewModel()
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    DireccionId = dto.DireccionId,
                    Direccion = direccion,
                    Paises = await _helperPais.PoblarSelect(),
                    PaisId = await _helperLocalidad.ObtenerPaisIdPorLocalidad(direccion.LocalidadId),
                    ProvinciaId = provinciaId,
                    Localidades = await _helperLocalidad.ObtenerLocalidadesPorProvincia(provinciaId),
                    Provincias = await _helperProvincia.PoblarSelect()
                };

                ViewBag.EstablecimientoDuplicado = false;
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EstablecimientoViewModel vm)
        {
            try
            {
                ViewBag.EstablecimientoDuplicado = false;
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado.");

                // comprobar si cambio la direccion
                var direccionId = await _helperDireccion.ExisteDireccion(vm.Direccion);
                if (!direccionId.HasValue)
                {
                    direccionId = await _helperDireccion.NuevaDireccion(vm.Direccion);
                }
                else
                {
                    var existe = await _establecimientoServicio.Existe(vm.Nombre, vm.Direccion.Descripcion,
                        vm.Direccion.LocalidadId, vm.Id);
                    if (existe)
                    {
                        ViewBag.EstablecimientoDuplicado = true;
                        throw new Exception("Establecimiento duplicado");
                    }
                }

                vm.DireccionId = direccionId.Value;

                var dto = new EstablecimientoDto()
                {
                    Id = vm.Id,
                    Nombre = vm.Nombre,
                    DireccionId = vm.DireccionId
                };

                await _establecimientoServicio.Modificar(dto);

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
                await _establecimientoServicio.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
