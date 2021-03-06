using System.Collections.Generic;
using System.Linq;
using EM.IServicio.Cliente;
using EM.IServicio.Cliente.Dto;
using EM.Presentacion.MVC.Models.Cliente;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Cliente
{
    public class HelperCliente : IHelperCliente
    {
        private readonly IClienteServicio _clienteServicio;

        public HelperCliente(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        public async Task<bool> ExisteCliente(string dni)
        {
            var existe = await _clienteServicio.ExisteClientePorDni(dni);

            return existe;
        }

        public async Task<bool> ExisteCliente(string dni, string email)
        {
            var existe = await _clienteServicio.ExisteClientePorDniEmail(dni, email);

            return existe;
        }

        public async Task<bool> NuevoCliente(ClienteViewModel model)
        {
            var dto = new ClienteDto()
            {
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Dni = model.Dni,
                Email = model.Email
            };

            await _clienteServicio.Insertar(dto);

            var existe = await ExisteCliente(model.Dni);

            return existe;
        }

        public async Task<ClienteViewModel> ObtenerClienteViewModelPorEmail(string email)
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

            return model;
        }

        public async Task<ClienteViewModel> Obtener(long clienteId)
        {
            var dto = (ClienteDto)await _clienteServicio.Obtener(clienteId);

            var model = new ClienteViewModel()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                Email = dto.Email,
                EstaEliminado = dto.EliminadoStr
            };

            return model;
        }

        public async Task<ClienteViewModel> Obtener(string dni)
        {
            var dto = (ClienteDto)((IEnumerable<ClienteDto>)await _clienteServicio.Obtener(dni, false)).FirstOrDefault(c => c.Dni.Equals(dni));

            var model = new ClienteViewModel()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                Email = dto.Email,
                EstaEliminado = dto.EliminadoStr
            };

            return model;
        }

        public async Task<ClienteViewModel> ObtenerNombreCliente(long id)
        {
            var dto = (ClienteDto)await _clienteServicio.Obtener(id);

            var model = new ClienteViewModel()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.Dni,
                Email = dto.Email,
                EstaEliminado = dto.EliminadoStr
            };
            return model;
        }
    }
}
