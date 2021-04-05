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
    }
}
