using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EM.Dominio.Repositorio.Cliente;
using EM.IServicio.Cliente;
using EM.IServicio.Cliente.Dto;
using EM.ServicioBase.Dto;
using Microsoft.EntityFrameworkCore;

namespace EM.Servicio.Cliente
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteServicio(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (ClienteDto)dtoBase;

            var cliente = _mapper.Map<Dominio.Entidades.Cliente>(dto);

            await _clienteRepositorio.Insertar(cliente);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (ClienteDto)dtoBase;

            var cliente = _mapper.Map<Dominio.Entidades.Cliente>(dto);

            await _clienteRepositorio.Actualizar(cliente);
        }

        public async Task Eliminar(long id)
        {
            await _clienteRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var cliente = await _clienteRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<ClienteDto>(cliente);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Cliente, bool>> filtro = x =>
                x.Nombre.Contains(cadenaBuscar) || x.Apellido.Contains(cadenaBuscar) || x.Dni.Equals(cadenaBuscar) &&
                (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var clientes = await _clienteRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

            return dtos;
        }

        public async Task<bool> ExisteClientePorDni(string dni)
        {
            Expression<Func<Dominio.Entidades.Cliente, bool>> filtro = x => x.Dni.Equals(dni);

            var clientes = await _clienteRepositorio.ObtenerFiltrado(filtro);

            return clientes.Any();
        }

        public async Task<DtoBase> ObtenerPorEmail(string email)
        {
            Expression<Func<Dominio.Entidades.Cliente, bool>> filtro = x => x.Email.Equals(email);

            var clientes = await _clienteRepositorio.ObtenerFiltrado(filtro);

            var cliente = clientes.First(c => c.Email == email);

            var dto = _mapper.Map<ClienteDto>(cliente);

            return dto;
        }
    }
}
