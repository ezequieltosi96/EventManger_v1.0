using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EM.IServicio.Cliente;
using EM.IServicio.Cliente.Dto;
using EM.Presentacion.MVC.Models.Cliente;
using Microsoft.AspNetCore.Authorization;

namespace EM.Presentacion.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        [Authorize(Roles = "Cliente, Admin")]
        public async Task<IActionResult> Profile(string email)
        {
            var dto = (ClienteDto)await _clienteServicio.ObtenerPorEmail(email);

            var model = new ClienteViewModel()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                Email = dto.Email,
                EstaEliminado = dto.EliminadoStr
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";

            var clientes = (IEnumerable<ClienteDto>)await _clienteServicio.Obtener(cadenaBuscar, mostrarTodos);

            var modelos = clientes.Select(c => new ClienteViewModel()
            {
                Id = c.Id,
                EstaEliminado = c.EliminadoStr,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Dni = c.Dni,
                Email = c.Email
            }).ToList();

            ViewBag.CadenaBuscar = cadenaBuscar;
            ViewBag.MostrarTodos = mostrarTodos;

            return View(modelos);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(long id)
        {
            var cliente = (ClienteDto)await _clienteServicio.Obtener(id);

            var model = new ClienteViewModel()
            {
                Id = cliente.Id,
                EstaEliminado = cliente.EliminadoStr,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Dni = cliente.Dni,
                Email = cliente.Email
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(long id)
        {
            var cliente = (ClienteDto)await _clienteServicio.Obtener(id);

            var model = new ClienteViewModel()
            {
                Id = cliente.Id,
                EstaEliminado = cliente.EliminadoStr,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Dni = cliente.Dni,
                Email = cliente.Email
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ClienteViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado.");

                var dto = new ClienteDto()
                {
                    Id = vm.Id,
                    Apellido = vm.Apellido,
                    Nombre = vm.Nombre,
                    Dni = vm.Dni,
                    Email = vm.Email
                };

                await _clienteServicio.Modificar(dto);

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
                await _clienteServicio.Eliminar(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
