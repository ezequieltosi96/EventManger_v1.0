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
using EM.Presentacion.MVC.Helpers.Empresa;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Controllers
{
    public class TipoEntradaController : Controller
    {
        private readonly ITipoEntradaServicio _tipoEntradaServicio;
        private readonly IHelperBeneficioEntrada _helperBeneficioEntrada;
        private readonly IHelperEmpresa _helperEmpresa;

        public TipoEntradaController(ITipoEntradaServicio tipoEntradaServicio, IHelperBeneficioEntrada helperBeneficioEntrada, IHelperEmpresa helperEmpresa)
        {
            _tipoEntradaServicio = tipoEntradaServicio;
            _helperBeneficioEntrada = helperBeneficioEntrada;
            _helperEmpresa = helperEmpresa;
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";

            IEnumerable<TipoEntradaDto> dtos;
            if (User.IsInRole("Empresa"))
            {
                var empresa = await _helperEmpresa.ObtenerEmpresaActual(User.Identity.Name);
                ViewBag.EmpresaId = empresa.Id;
                dtos = (IEnumerable<TipoEntradaDto>)await _tipoEntradaServicio.ObtenerPorEmpresa(empresa.Id, cadenaBuscar, mostrarTodos);
            }
            else
            {
                ViewBag.EmpresaId = null;
                dtos = (IEnumerable<TipoEntradaDto>)await _tipoEntradaServicio.Obtener(cadenaBuscar, mostrarTodos);
            }

            var models = dtos.Select(b => new TipoEntradaViewModel()
            {
                Id = b.Id,
                EstaEliminado = b.EliminadoStr,
                Nombre = b.Nombre,
                EmpresaId = b.EmpresaId,
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

        [Authorize(Roles = "Admin, Empresa")]
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
                    EmpresaId = dto.EmpresaId,
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

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Create(long? empresaId = null)
        {
            ViewBag.EmpresaId = empresaId;

            var beneficiosEntrada = await _helperBeneficioEntrada.PoblarSelect();

            if (empresaId.HasValue)
            {
                return View(new TipoEntradaViewModel()
                {
                    BeneficiosEntrada = beneficiosEntrada,
                    EmpresaId = empresaId.Value
                });
            }

            var empresas = await _helperEmpresa.PoblarCombo();

            return View(new TipoEntradaViewModel()
            {
                BeneficiosEntrada = beneficiosEntrada,
                Empresas = empresas
            });
        }

        [Authorize(Roles = "Admin, Empresa")]
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
                    BeneficioEntradaId = vm.BeneficioEntradaId,
                    EmpresaId = vm.EmpresaId
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

                var beneficiosEntrada = await _helperBeneficioEntrada.PoblarSelect();

                var vm = new TipoEntradaViewModel()
                {
                    Id = dto.Id,
                    EstaEliminado = dto.EliminadoStr,
                    Nombre = dto.Nombre,
                    EmpresaId = dto.EmpresaId,
                    BeneficioEntradaId = dto.BeneficioEntradaId,
                    BeneficioEntradaNombre = await _helperBeneficioEntrada.ObtenerNombreBeneficioEntrada(dto.BeneficioEntradaId),
                    BeneficiosEntrada = beneficiosEntrada
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
                    EmpresaId = vm.EmpresaId,
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
