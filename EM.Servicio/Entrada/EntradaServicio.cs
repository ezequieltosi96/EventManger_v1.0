namespace EM.Servicio.Entrada
{
    using AutoMapper;
    using EM.Dominio.Repositorio.Entrada;
    using EM.IServicio.Entrada;
    using EM.IServicio.Entrada.Dto;
    using EM.ServicioBase.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class EntradaServicio : IEntradaServicio
    {
        private readonly IEntradaRepositorio _entradaRepositorio;
        private readonly IMapper _mapper;
        public EntradaServicio(IEntradaRepositorio entradaRepositorio, IMapper mapper)
        {
            _entradaRepositorio = entradaRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (EntradaDto)dtoBase;

            var entrada = _mapper.Map<Dominio.Entidades.Entrada>(dto);

            await _entradaRepositorio.Insertar(entrada);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (EntradaDto)dtoBase;

            var entrada = _mapper.Map<Dominio.Entidades.Entrada>(dto);

            await _entradaRepositorio.Actualizar(entrada);
        }

        public async Task Eliminar(long id)
        {
            await _entradaRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var entrada = await _entradaRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<EntradaDto>(entrada);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Entrada, bool>> filtro = x => !x.EstaEliminado;

            if (mostrarTodos) filtro = x => x.EstaEliminado && !x.EstaEliminado;

            var entradas = await _entradaRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<EntradaDto>>(entradas);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerGenericByEvento(long eventoId, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Entrada, bool>> filtro = x => !x.EstaEliminado && x.EventoId == eventoId && x.ClienteId == null;

            if (mostrarTodos) filtro = x => x.EventoId == eventoId && x.ClienteId == null;

            var entradas = await _entradaRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<EntradaDto>>(entradas);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerByEvento(long eventoId, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Entrada, bool>> filtro = x => !x.EstaEliminado && x.EventoId == eventoId && x.ClienteId != null;

            if (mostrarTodos) filtro = x => x.EventoId == eventoId && x.ClienteId != null;

            var entradas = await _entradaRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<EntradaDto>>(entradas);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerByCliente(long clienteId)
        {
            Expression<Func<Dominio.Entidades.Entrada, bool>> filtro = x => !x.EstaEliminado && x.ClienteId == clienteId;

            var entradas = await _entradaRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<EntradaDto>>(entradas);

            return dtos;
        }
    }
}
