using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Pais;
using EM.IServicio.Pais.Dto;
using EM.Presentacion.MVC.Models.Pais;

namespace EM.Presentacion.MVC.Controllers
{
    public class PaisController : Controller
    {
        private readonly IPaisServicio _paisServicio;

        public PaisController(IPaisServicio paisServicio)
        {
            _paisServicio = paisServicio;
        }

        // GET: PaisController
        public async Task<IActionResult> Index()
        {
            var dtos = (IEnumerable<PaisDto>)await _paisServicio.Obtener(String.Empty, false);

            var models = dtos.Select(d => new PaisViewModel()
            {
                Id = d.Id,
                EstaEliminado = d.EliminadoStr,
                Nombre = d.Nombre
            }).ToList();

            return View(models);
        }

        // GET: PaisController/Details/5
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
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: PaisController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaisController/Create
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
            catch (Exception e)
            {
                return View(vm);
            }
        }

        // GET: PaisController/Edit/5
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
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: PaisController/Edit/5
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
            catch
            {
                return View(vm.Id);
            }
        }

        // GET: PaisController/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _paisServicio.Eliminar(id);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }

        // POST: PaisController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(PaisViewModel vm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            throw new Exception("Error de validacion no controlado");
        //        }

        //        var paisDto = new PaisDto()
        //        {
        //            Id = vm.Id,
        //            EstaEliminado = vm.EstaEliminado.Equals("Si"),
        //            Nombre = vm.Nombre,
        //        };

        //        await _paisServicio.Modificar(paisDto);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View(vm.Id);
        //    }
        //}
    }
}
