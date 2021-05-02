using EM.IServicio.Actividad;
using EM.IServicio.Actividad.Dto;
using EM.Presentacion.MVC.Helpers.Disertante;
using EM.Presentacion.MVC.Helpers.Sala;
using EM.Presentacion.MVC.Models.Actividad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Controllers
{
    public class ActividadController : Controller
    {
        private readonly IActividadServicio _actividadServicio;
        private readonly IHelperSala _helperSala;
        private readonly IHelperDisertante _helperDisertante;

        public ActividadController(IActividadServicio actividadServicio, IHelperSala helperSala, IHelperDisertante helperDisertante)
        {
            _actividadServicio = actividadServicio;
            _helperSala = helperSala;
            _helperDisertante = helperDisertante;
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Create(long eventoId, long establecimientoId, long empresaId, string fecha, long? vbEmpresa = null)
        {
            try
            {
                var fechaDt = DateTime.Parse(fecha);
                ViewBag.EmpresaId = vbEmpresa;
                ViewBag.EventoId = eventoId;

                var model = new ActividadViewModel()
                {
                    EventoId = eventoId,
                    Fecha = fechaDt.Date.Date,
                    Hora = fechaDt,
                    Salas = await _helperSala.PoblarComboPorEstablecimiento(establecimientoId, fechaDt),
                    Disertantes = await _helperDisertante.PoblarComboPorEmpresa(empresaId, fechaDt),
                };

                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Details", "Evento", new { eventoId });
            }
        }

        [Authorize(Roles = "Admin, Empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActividadViewModel vm, long? vbEmpresa = null)
        {
            try
            {
                ViewBag.EmpresaId = vbEmpresa;
                ViewBag.EventoId = vm.EventoId;
                if (!ModelState.IsValid)
                {
                    throw new Exception("Error de validacion no controlado.");
                }

                var fecha = vm.Fecha.Date + vm.Hora.TimeOfDay;

                var dto = new ActividadDto()
                {
                    DisertanteId = vm.DisertanteId,
                    EventoId = vm.EventoId,
                    FechaHora = fecha,
                    SalaId = vm.SalaId,
                    Nombre = vm.Nombre,
                };

                // validar
                // que el disertante este disponible (no exista una actividad con el mismo disertante para la misma fecha y hora)
                if (!await _actividadServicio.DisertanteEstaDisponible(vm.DisertanteId, fecha))
                {
                    throw new Exception("El disertante no esta disponible.");
                }
                // que la sala este disponible (que no exista una actividad con la misma sala para la misma fecha
                if (!await _actividadServicio.SalaEstaDisponible(vm.SalaId, fecha))
                {
                    throw new Exception("La sala no esta disponible.");
                }
                // que la actividad no este duplicada (que no exista una actividad con el mismo nombre para el mismo evento)
                if (await _actividadServicio.Existe(vm.Nombre, vm.EventoId))
                {
                    throw new Exception("Ya existe una actividad con ese nombre.");
                }

                // crear
                await _actividadServicio.Insertar(dto);

                return RedirectToAction("Details", "Evento", new { id = vm.EventoId, vbEmpresa });
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        public async Task<IActionResult> Delete(long id, long eventoId)
        {
            try
            {
                await _actividadServicio.Eliminar(id);

                return RedirectToAction("Details", "Evento", new { id = eventoId });
            }
            catch (Exception)
            {
                return RedirectToAction("Details", "Evento", new { id = eventoId });
            }
        }

        //public IActionResult CreatePartial(long eventoId)
        //{
        //    var model = new ActividadViewModel()
        //    {
        //        EventoId = eventoId
        //    };

        //    return PartialView(model);
        //}
    }
}
