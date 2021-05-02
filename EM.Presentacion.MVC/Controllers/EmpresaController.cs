using EM.IServicio.Empresa;
using EM.IServicio.Empresa.Dto;
using EM.Presentacion.MVC.Helpers.Direccion;
using EM.Presentacion.MVC.Helpers.Localidad;
using EM.Presentacion.MVC.Helpers.Pais;
using EM.Presentacion.MVC.Helpers.Provincia;
using EM.Presentacion.MVC.Models.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaServicio _empresaServicio;
        private readonly IHelperDireccion _helperDireccion;
        private readonly IHelperPais _helperPais;
        private readonly IHelperLocalidad _helperLocalidad;
        private readonly IHelperProvincia _helperProvincia;

        public EmpresaController(IEmpresaServicio empresaServicio, IHelperDireccion helperDireccion, IHelperPais helperPais, IHelperLocalidad helperLocalidad, IHelperProvincia helperProvincia)
        {
            _empresaServicio = empresaServicio;
            _helperDireccion = helperDireccion;
            _helperPais = helperPais;
            _helperLocalidad = helperLocalidad;
            _helperProvincia = helperProvincia;
        }

        [Authorize(Roles = "Empresa, Admin")]
        public async Task<IActionResult> Profile(string email)
        {
            var dto = (EmpresaDto)await _empresaServicio.ObtenerPorEmail(email);

            var direccionVm = await _helperDireccion.ObtenerDireccion(dto.DireccionId);

            var model = new EmpresaViewModel()
            {
                RazonSocial = dto.RazonSocial,
                NombreFantasia = dto.NombreFantasia,
                Cuil = dto.Cuil,
                DireccionStr = direccionVm.Descripcion,
                Direccion = direccionVm,
                Email = dto.Email,
                EstaEliminado = dto.EliminadoStr,
                Id = dto.Id
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";
            var empresas = (IEnumerable<EmpresaDto>)await _empresaServicio.Obtener(cadenaBuscar, mostrarTodos);

            var models = empresas.Select(e => new EmpresaViewModel()
            {
                Id = e.Id,
                EstaEliminado = e.EliminadoStr,
                Cuil = e.Cuil,
                DireccionId = e.DireccionId,
                Email = e.Email,
                NombreFantasia = e.NombreFantasia,
                RazonSocial = e.RazonSocial,
            }).ToList();

            foreach (var m in models)
            {
                m.Direccion = await _helperDireccion.ObtenerDireccion(m.DireccionId);
                m.DireccionStr = m.Direccion.Descripcion;
            }

            ViewBag.CadenaBuscar = cadenaBuscar;
            ViewBag.MostrarTodos = mostrarTodos;

            return View(models);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                var dto = (EmpresaDto)await _empresaServicio.Obtener(id);

                var direccion = await _helperDireccion.ObtenerDireccion(dto.DireccionId);
                var provinciaId = await _helperLocalidad.ObtenerProvinciaIdPorLocalidad(direccion.LocalidadId);

                var model = new EmpresaViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Cuil = dto.Cuil,
                    DireccionId = dto.DireccionId,
                    Email = dto.Email,
                    NombreFantasia = dto.NombreFantasia,
                    RazonSocial = dto.RazonSocial,
                    Direccion = direccion,
                    DireccionStr = direccion.Descripcion,
                    PaisId = await _helperLocalidad.ObtenerPaisIdPorLocalidad(direccion.LocalidadId),
                    Paises = await _helperPais.PoblarSelect(),
                    ProvinciaId = provinciaId,
                    Provincias = await _helperProvincia.PoblarSelect(),
                    Localidades = await _helperLocalidad.ObtenerLocalidadesPorProvincia(provinciaId)
                };

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
        public async Task<IActionResult> Edit(EmpresaViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado.");

                // comprobar si cambio la direccion
                var direccionId = await _helperDireccion.ExisteDireccion(vm.Direccion);
                if (!direccionId.HasValue)
                {
                    direccionId = await _helperDireccion.NuevaDireccion(vm.Direccion);
                }

                vm.DireccionId = direccionId.Value;

                var dto = new EmpresaDto()
                {
                    Id = vm.Id,
                    Cuil = vm.Cuil,
                    DireccionId = vm.DireccionId,
                    Email = vm.Email,
                    NombreFantasia = vm.NombreFantasia,
                    RazonSocial = vm.RazonSocial,
                };

                await _empresaServicio.Modificar(dto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(long id)
        {
            var dto = (EmpresaDto)await _empresaServicio.Obtener(id);

            var direccion = await _helperDireccion.ObtenerDireccion(dto.DireccionId);

            var model = new EmpresaViewModel()
            {
                Id = dto.Id,
                EstaEliminado = dto.EliminadoStr,
                Cuil = dto.Cuil,
                DireccionId = dto.DireccionId,
                Email = dto.Email,
                NombreFantasia = dto.NombreFantasia,
                RazonSocial = dto.RazonSocial,
                Direccion = direccion,
                DireccionStr = direccion.Descripcion
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _empresaServicio.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
