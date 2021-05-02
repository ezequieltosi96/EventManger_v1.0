using EM.IServicio.Sala;
using EM.IServicio.Sala.Dto;
using EM.Presentacion.MVC.Helpers.Establecimiento;
using EM.Presentacion.MVC.Models.Sala;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Controllers
{
    public class SalaController : Controller
    {
        private readonly ISalaServicio _salaServicio;
        private readonly IHelperEstablecimiento _helperEstablecimiento;

        public SalaController(ISalaServicio salaServicio, IHelperEstablecimiento helperEstablecimiento)
        {
            _salaServicio = salaServicio;
            _helperEstablecimiento = helperEstablecimiento;
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Index(long? establecimientoId = null, string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";
            ViewBag.EstablecimientoId = null;
            IEnumerable<SalaDto> salas;
            if (!establecimientoId.HasValue)
            {
                salas = (IEnumerable<SalaDto>)await _salaServicio.Obtener(cadenaBuscar, mostrarTodos);
            }
            else
            {
                salas = (IEnumerable<SalaDto>)await _salaServicio.ObtenerPorEstablecimiento(establecimientoId.Value,
                    cadenaBuscar, mostrarTodos);
                ViewBag.EstablecimientoId = establecimientoId.Value;
            }

            var models = salas.Select(s => new SalaViewModel()
            {
                Id = s.Id,
                Nombre = s.Nombre,
                EstablecimientoId = s.EstablecimientoId,
                EstaEliminado = s.EliminadoStr
            }).ToList();

            foreach (var m in models)
            {
                m.Establecimiento = await _helperEstablecimiento.ObtenerEstablecimiento(m.EstablecimientoId);
            }

            ViewBag.CadenaBuscar = cadenaBuscar;
            ViewBag.MostrarTodos = mostrarTodos;

            return View(models);
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Create(long? establecimientoId = null)
        {
            try
            {
                SalaViewModel model = null;

                if (establecimientoId.HasValue)
                {
                    model = new SalaViewModel()
                    {
                        EstablecimientoId = establecimientoId.Value
                    };
                    ViewBag.EstablecimientoId = establecimientoId.Value;
                }
                else
                {
                    model = new SalaViewModel()
                    {
                        Establecimientos = await _helperEstablecimiento.PoblarCombo()
                    };
                    ViewBag.EstablecimientoId = null;
                }

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), new { establecimientoId });
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalaViewModel vm, long? vbEstablecimiento = null)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.EstablecimientoId = vbEstablecimiento.HasValue ? vbEstablecimiento.Value : (dynamic)null;
                    throw new Exception("Error de validacion no controlado.");
                }

                var dto = new SalaDto()
                {
                    Nombre = vm.Nombre,
                    EstablecimientoId = vm.EstablecimientoId
                };

                await _salaServicio.Insertar(dto);

                return RedirectToAction(nameof(Index), new { establecimientoId = vbEstablecimiento });
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Details(long id, long? vbEstablecimiento = null)
        {
            try
            {
                var dto = (SalaDto)await _salaServicio.Obtener(id);

                var model = new SalaViewModel()
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    EstablecimientoId = dto.EstablecimientoId,
                    EstaEliminado = dto.EliminadoStr,
                    Establecimiento = await _helperEstablecimiento.ObtenerEstablecimiento(dto.EstablecimientoId)
                };

                ViewBag.EstablecimientoId = vbEstablecimiento;

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), new { establecimientoId = vbEstablecimiento });
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(long id, long? vbEstablecimiento = null)
        {
            try
            {
                var dto = (SalaDto)await _salaServicio.Obtener(id);

                var model = new SalaViewModel()
                {
                    Id = dto.Id,
                    Nombre = dto.Nombre,
                    EstablecimientoId = dto.EstablecimientoId,
                    EstaEliminado = dto.EliminadoStr,
                    Establecimiento = await _helperEstablecimiento.ObtenerEstablecimiento(dto.EstablecimientoId),
                    Establecimientos = await _helperEstablecimiento.PoblarCombo()
                };

                ViewBag.EstablecimientoId = vbEstablecimiento;

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), new { establecimientoId = vbEstablecimiento });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SalaViewModel vm, long? vbEstablecimiento = null)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.EstablecimientoId = vbEstablecimiento.HasValue ? vbEstablecimiento.Value : (dynamic)null;
                    throw new Exception("Error de validacion no controlado.");
                }

                var dto = new SalaDto()
                {
                    Id = vm.Id,
                    Nombre = vm.Nombre,
                    EstablecimientoId = vm.EstablecimientoId
                };

                await _salaServicio.Modificar(dto);

                return RedirectToAction(nameof(Index), new { establecimientoId = vbEstablecimiento });
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id, long? vbEstablecimiento = null)
        {
            try
            {
                await _salaServicio.Eliminar(id);

                return RedirectToAction(nameof(Index), new { establecimientoId = vbEstablecimiento });
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), new { establecimientoId = vbEstablecimiento });
            }
        }
    }
}
