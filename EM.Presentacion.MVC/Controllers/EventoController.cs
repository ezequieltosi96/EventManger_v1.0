using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EM.IServicio.Evento;
using EM.IServicio.Evento.Dto;
using EM.Presentacion.MVC.Helpers.Actividad;
using EM.Presentacion.MVC.Helpers.Disertante;
using EM.Presentacion.MVC.Helpers.Empresa;
using EM.Presentacion.MVC.Helpers.Establecimiento;
using EM.Presentacion.MVC.Helpers.Sala;
using EM.Presentacion.MVC.Models.Actividad;
using EM.Presentacion.MVC.Models.Evento;
using Microsoft.AspNetCore.Authorization;

namespace EM.Presentacion.MVC.Controllers
{
    public class EventoController : Controller
    {
        private readonly IEventoServicio _eventoServicio;
        private readonly IHelperEmpresa _helperEmpresa;
        private readonly IHelperEstablecimiento _helperEstablecimiento;
        private readonly IHelperDisertante _helperDisertante;
        private readonly IHelperSala _helperSala;
        private readonly IHelperActividad _helperActividad;

        public EventoController(IEventoServicio eventoServicio, IHelperEmpresa helperEmpresa, IHelperEstablecimiento helperEstablecimiento, IHelperDisertante helperDisertante, IHelperSala helperSala, IHelperActividad helperActividad)
        {
            _eventoServicio = eventoServicio;
            _helperEmpresa = helperEmpresa;
            _helperEstablecimiento = helperEstablecimiento;
            _helperDisertante = helperDisertante;
            _helperSala = helperSala;
            _helperActividad = helperActividad;
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Index(long? empresaId = null, string cadenaBuscar = "", bool mostrarTodos = false)
        {
            // si empresaId == null muestro todos los eventos sino muestro solo los de la empresa
            if (cadenaBuscar == null) cadenaBuscar = "";
            IEnumerable<EventoDto> eventos;
            if (!empresaId.HasValue)
            {
                if (User.IsInRole("Admin"))
                {
                    eventos = (IEnumerable<EventoDto>)await _eventoServicio.Obtener(cadenaBuscar, mostrarTodos);
                }
                else
                {
                    var empresa = await _helperEmpresa.ObtenerEmpresaActual(User.Identity.Name);
                    empresaId = empresa.Id;
                    eventos = (IEnumerable<EventoDto>)await _eventoServicio.ObtenerPorEmpresa(empresaId.Value, cadenaBuscar, mostrarTodos);
                }

            }
            else
            {
                eventos = (IEnumerable<EventoDto>)await _eventoServicio.ObtenerPorEmpresa(empresaId.Value, cadenaBuscar, mostrarTodos);
            }

            var models = eventos.Select(e => new EventoViewModel()
            {
                Id = e.Id,
                EstaEliminado = e.EliminadoStr,
                Nombre = e.Nombre,
                Descripcion = e.Descripcion,
                Cupo = e.Cupo,
                EstablecimientoId = e.EstalecimientoId,
                EmpresaId = e.EmpresaId,
                Fecha = e.Fecha,
                Actividades = e.Actividades.Select(a => new ActividadViewModel()
                {
                    Id = a.Id,
                    Nombre = a.Nombre,
                    DisertanteId = a.DisertanteId,
                    EstaEliminado = a.EliminadoStr,
                    FechaHora = a.FechaHora,
                    SalaId = a.SalaId,
                    EventoId = a.EventoId
                }).ToList(),
            }).ToList();

            foreach (var m in models)
            {
                m.Empresa = await _helperEmpresa.ObtenerEmpresa(m.EmpresaId);
                m.Establecimiento = await _helperEstablecimiento.ObtenerEstablecimiento(m.EstablecimientoId);
                foreach (var a in m.Actividades)
                {
                    a.Disertante = await _helperDisertante.ObtenerDisertante(a.DisertanteId);
                    a.Sala = await _helperSala.ObtenerSala(a.SalaId);
                }
            }

            ViewBag.CadenaBuscar = cadenaBuscar;
            ViewBag.MostrarTodos = mostrarTodos;
            ViewBag.EmpresaId = empresaId;

            return View(models);
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Details(long id, long? vbEmpresa = null)
        {
            try
            {
                ViewBag.EmpresaId = vbEmpresa;

                var evento = (EventoDto)await _eventoServicio.Obtener(id);

                var model = new EventoViewModel()
                {
                    Id = evento.Id,
                    EstaEliminado = evento.EliminadoStr,
                    Cupo = evento.Cupo,
                    Nombre = evento.Nombre,
                    Descripcion = evento.Descripcion,
                    Fecha = evento.Fecha,
                    EmpresaId = evento.EmpresaId,
                    EstablecimientoId = evento.EstalecimientoId,
                    Actividades = evento.Actividades.Select(a => new ActividadViewModel()
                    {
                        Id = a.Id,
                        DisertanteId = a.DisertanteId,
                        EstaEliminado = a.EliminadoStr,
                        EventoId = a.EventoId,
                        SalaId = a.SalaId,
                        FechaHora = a.FechaHora,
                        Nombre = a.Nombre,
                        Disertante = _helperDisertante.ObtenerDisertante(a.DisertanteId).Result,
                        Sala = _helperSala.ObtenerSala(a.SalaId).Result
                    }),
                    Empresa = _helperEmpresa.ObtenerEmpresa(evento.EmpresaId).Result,
                    Establecimiento = _helperEstablecimiento.ObtenerEstablecimiento(evento.EstalecimientoId).Result,
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), new { empresaId = vbEmpresa });
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Create(long? vbEmpresa = null)
        {
            try
            {
                EventoViewModel model;
                ViewBag.EmpresaId = vbEmpresa;
                ViewBag.EventoDuplicado = false;
                ViewBag.EstablecimientoNoDisponible = false;

                // TODO filtrar establecimientos por ubicacion (pais-provincia-localidad)

                // aqui se debe poblar el combo de pais y los demas se iran poblando dinamicamente hasta llegar a establecimiento
                // cuando se pueble el de establecimiento se tiene que verificar si el establecimiento tiene una sala disponible
                // para la fecha especificada para que no se carguen establecimientos no validos.

                if (vbEmpresa.HasValue) // pueblo los combos excluyendo el de empresa
                {

                    model = new EventoViewModel()
                    {
                        EmpresaId = vbEmpresa.Value,
                        Establecimientos = await _helperEstablecimiento.PoblarCombo(),
                        Fecha = DateTime.Today
                    };
                }
                else // pueblo los combos incluyendo el de empresa
                {

                    model = new EventoViewModel()
                    {
                        Empresas = await _helperEmpresa.PoblarCombo(),
                        Establecimientos = await _helperEstablecimiento.PoblarCombo(),
                        Fecha = DateTime.Today
                    };
                }

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), new { empresaId = vbEmpresa });
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventoViewModel vm, long? vbEmpresa = null)
        {
            try
            {
                ViewBag.EmpresaId = vbEmpresa;
                ViewBag.EventoDuplicado = false;
                ViewBag.EstablecimientoNoDisponible = false;
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado.");

                var dto = new EventoDto()
                {
                    Cupo = vm.Cupo,
                    Descripcion = vm.Descripcion,
                    EmpresaId = vm.EmpresaId,
                    EstalecimientoId = vm.EstablecimientoId,
                    Fecha = vm.Fecha,
                    Nombre = vm.Nombre
                };

                // Validar la duplicidad del evento (misma empresa mismo nombre misma fecha mismo establecimiento)
                var existe = await _eventoServicio.Existe(dto);
                if (existe)
                {
                    ViewBag.EventoDuplicado = true;
                    if (!vbEmpresa.HasValue)
                        vm.Empresas = await _helperEmpresa.PoblarCombo();
                    vm.Establecimientos = await _helperEstablecimiento.PoblarCombo();
                    throw new Exception("Evento Duplicado.");
                }

                // Validar que el establecimiento tenga una sala disponibles para esa fecha
                var disponible =
                    await _helperSala.ExisteSalaDisponible(vm.EstablecimientoId, vm.Fecha);
                if (!disponible)
                {
                    ViewBag.EstablecimientoNoDisponible = true;
                    if (!vbEmpresa.HasValue)
                        vm.Empresas = await _helperEmpresa.PoblarCombo();
                    vm.Establecimientos = await _helperEstablecimiento.PoblarCombo();
                    throw new Exception("El establecimiento no tiene salas disponibles.");
                }

                await _eventoServicio.Insertar(dto);

                return RedirectToAction(nameof(Index), new { empresaId = vbEmpresa });

            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(long id, long? vbEmpresa = null)
        {
            try
            {
                ViewBag.EmpresaId = vbEmpresa;
                ViewBag.EventoDuplicado = false;
                ViewBag.EstablecimientoNoDisponible = false;

                var evento = (EventoDto)await _eventoServicio.Obtener(id);

                var model = new EventoViewModel()
                {
                    Id = evento.Id,
                    EstaEliminado = evento.EliminadoStr,
                    Cupo = evento.Cupo,
                    Nombre = evento.Nombre,
                    Descripcion = evento.Descripcion,
                    Fecha = evento.Fecha,
                    EmpresaId = evento.EmpresaId,
                    EstablecimientoId = evento.EstalecimientoId,
                    Empresas = await _helperEmpresa.PoblarCombo(),
                    Establecimientos = await _helperEstablecimiento.PoblarCombo()
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), new { empresaId = vbEmpresa });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventoViewModel vm, long? vbEmpresa = null)
        {
            try
            {
                ViewBag.EmpresaId = vbEmpresa;
                ViewBag.EventoDuplicado = false;
                ViewBag.EstablecimientoNoDisponible = false;
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado.");

                var dto = new EventoDto()
                {
                    Id = vm.Id,
                    Cupo = vm.Cupo,
                    Descripcion = vm.Descripcion,
                    EmpresaId = vm.EmpresaId,
                    EstalecimientoId = vm.EstablecimientoId,
                    Fecha = vm.Fecha,
                    Nombre = vm.Nombre
                };

                // Validar la duplicidad del evento (misma empresa mismo nombre misma fecha mismo establecimiento)
                var existe = await _eventoServicio.Existe(dto);
                if (existe)
                {
                    ViewBag.EventoDuplicado = true;
                    if (!vbEmpresa.HasValue)
                        vm.Empresas = await _helperEmpresa.PoblarCombo();
                    vm.Establecimientos = await _helperEstablecimiento.PoblarCombo();
                    throw new Exception("Evento Duplicado.");
                }

                // Validar que el establecimiento tenga una sala disponibles para esa fecha
                var disponible =
                    await _helperSala.ExisteSalaDisponible(vm.EstablecimientoId, vm.Fecha, vm.Id);
                if (!disponible)
                {
                    ViewBag.EstablecimientoNoDisponible = true;
                    if (!vbEmpresa.HasValue)
                        vm.Empresas = await _helperEmpresa.PoblarCombo();
                    vm.Establecimientos = await _helperEstablecimiento.PoblarCombo();
                    throw new Exception("El establecimiento no tiene salas disponibles.");
                }

                await _eventoServicio.Modificar(dto);

                return RedirectToAction(nameof(Index), new { empresaId = vbEmpresa });

            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id, long? vbEmpresa = null)
        {
            try
            {
                await _eventoServicio.Eliminar(id);

                return RedirectToAction(nameof(Index), new { empresaId = vbEmpresa });
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index), new { empresaId = vbEmpresa });
            }
        }
    }
}
