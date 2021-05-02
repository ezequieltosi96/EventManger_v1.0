using EM.IServicio.Disertante;
using EM.IServicio.Disertante.Dto;
using EM.Presentacion.MVC.Helpers.Empresa;
using EM.Presentacion.MVC.Models.Disertante;
using EM.Presentacion.MVC.Models.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Controllers
{
    public class DisertanteController : Controller
    {
        private readonly IDisertanteServicio _disertanteServicio;
        private readonly IHelperEmpresa _helperEmpresa;

        public DisertanteController(IDisertanteServicio disertanteServicio, IHelperEmpresa helperEmpresa)
        {
            _disertanteServicio = disertanteServicio;
            _helperEmpresa = helperEmpresa;
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false, long? empresaId = null)
        {
            EmpresaViewModel empresa = null;
            ViewBag.EmpresaId = null;

            if (empresaId.HasValue) // si tiene empresaId es que estoy entrando como administrador
            {
                empresa = await _helperEmpresa.ObtenerEmpresa(empresaId.Value);
                ViewBag.EmpresaId = empresaId.Value;
                if (empresa == null) return RedirectToAction("Index", "Empresa");
            }
            else // sino la empresaId la extrae desde el usuario logueado
            {
                empresa = await _helperEmpresa.ObtenerEmpresaActual(User.Identity.Name);
            }

            if (cadenaBuscar == null) cadenaBuscar = "";
            var disertantes = (IEnumerable<DisertanteDto>)await _disertanteServicio.ObtenerPorEmpresa(empresa.Id, cadenaBuscar, mostrarTodos);

            var models = disertantes.Select(d => new DisertanteViewModel()
            {
                Id = d.Id,
                Apellido = d.Apellido,
                Nombre = d.Nombre,
                Dni = d.Dni,
                Empresa = empresa,
                EmpresaId = d.EmpresaId,
                EstaEliminado = d.EliminadoStr
            }).ToList();

            ViewBag.CadenaBuscar = cadenaBuscar;
            ViewBag.MostrarTodos = mostrarTodos;

            return View(models);
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Details(long id)
        {
            try
            {
                ViewBag.EmpresaId = null;

                var disertante = (DisertanteDto)await _disertanteServicio.Obtener(id);

                var empresa = await _helperEmpresa.ObtenerEmpresa(disertante.EmpresaId);

                if (User.IsInRole("Admin"))
                {
                    ViewBag.EmpresaId = disertante.EmpresaId;
                }

                var model = new DisertanteViewModel()
                {
                    Id = disertante.Id,
                    Apellido = disertante.Apellido,
                    Nombre = disertante.Nombre,
                    Dni = disertante.Dni,
                    Empresa = empresa,
                    EmpresaId = disertante.EmpresaId,
                    EstaEliminado = disertante.EliminadoStr
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Create(long? empresaId = null)
        {
            EmpresaViewModel empresa = null;
            ViewBag.EmpresaId = null;

            if (empresaId.HasValue) // si tiene empresaId es que estoy entrando como administrador
            {
                empresa = await _helperEmpresa.ObtenerEmpresa(empresaId.Value);
                ViewBag.EmpresaId = empresaId.Value;
                if (empresa == null) return RedirectToAction("Index", "Empresa");
            }
            else // sino la empresaId la extrae desde el usuario logueado
            {
                empresa = await _helperEmpresa.ObtenerEmpresaActual(User.Identity.Name);
            }

            var model = new DisertanteViewModel()
            {
                EmpresaId = empresa.Id
            };

            return View(model);
        }

        [Authorize(Roles = "Admin, Empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DisertanteViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado.");

                var dto = new DisertanteDto()
                {
                    Apellido = vm.Apellido,
                    Dni = vm.Dni,
                    EmpresaId = vm.EmpresaId,
                    Nombre = vm.Nombre,
                };

                await _disertanteServicio.Insertar(dto);

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(Index), new { empresaId = vm.EmpresaId });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Edit(long id)
        {
            var dto = (DisertanteDto)await _disertanteServicio.Obtener(id);

            var model = new DisertanteViewModel()
            {
                Id = dto.Id,
                Apellido = dto.Apellido,
                Nombre = dto.Nombre,
                Dni = dto.Dni,
                EmpresaId = dto.EmpresaId
            };

            ViewBag.EmpresaId = null;
            if (User.IsInRole("Admin"))
            {
                ViewBag.EmpresaId = dto.EmpresaId;
            }

            return View(model);
        }

        [Authorize(Roles = "Admin, Empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DisertanteViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado.");

                var dto = new DisertanteDto()
                {
                    Id = vm.Id,
                    Apellido = vm.Apellido,
                    Dni = vm.Dni,
                    EmpresaId = vm.EmpresaId,
                    Nombre = vm.Nombre,
                };

                await _disertanteServicio.Modificar(dto);

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(Index), new { empresaId = vm.EmpresaId });
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Delete(long id, long empresaId)
        {
            try
            {
                await _disertanteServicio.Eliminar(id);

                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(Index), new { empresaId });
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
