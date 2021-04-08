using System.Linq;

namespace EM.Servicio.Evento
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Evento;
    using EM.IServicio.Evento;
    using EM.IServicio.Evento.Dto;
    using EM.ServicioBase.Dto;
    using Microsoft.EntityFrameworkCore;

    public class EventoServicio : IEventoServicio
    {
        private readonly IEventoRepositorio _eventoRepositorio;
        private readonly IMapper _mapper;

        public EventoServicio(IEventoRepositorio eventoRepositorio, IMapper mapper)
        {
            _eventoRepositorio = eventoRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (EventoDto)dtoBase;

            var evento = _mapper.Map<Dominio.Entidades.Evento>(dto);

            await _eventoRepositorio.Insertar(evento);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (EventoDto)dtoBase;

            var evento = _mapper.Map<Dominio.Entidades.Evento>(dto);

            await _eventoRepositorio.Actualizar(evento);
        }

        public async Task Eliminar(long id)
        {
            await _eventoRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var evento = await _eventoRepositorio.ObtenerPorId(id, x => x.Include(e => e.Actividades));

            var dto = _mapper.Map<EventoDto>(evento);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Evento, bool>> filtro = x =>
                x.Nombre.Contains(cadenaBuscar) && !x.EstaEliminado;

            if (mostrarTodos)
                filtro = x =>
                    x.Nombre.Contains(cadenaBuscar);

            var eventos = await _eventoRepositorio.ObtenerFiltrado(filtro, x => x.OrderBy(e => e.Fecha).ThenBy(e => e.Nombre), x => x.Include(e => e.Actividades));

            var dtos = _mapper.Map<IEnumerable<EventoDto>>(eventos);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerPorEmpresa(long empresaId, string cadenaBuscar = "", bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Evento, bool>> filtro = x =>
                x.Nombre.Contains(cadenaBuscar) && x.EmpresaId == empresaId && !x.EstaEliminado;

            if (mostrarTodos)
                filtro = x =>
                    x.Nombre.Contains(cadenaBuscar) && x.EmpresaId == empresaId;

            var eventos = await _eventoRepositorio.ObtenerFiltrado(filtro, x => x.OrderBy(e => e.Fecha).ThenBy(e => e.Nombre), x => x.Include(e => e.Actividades));

            var dtos = _mapper.Map<IEnumerable<EventoDto>>(eventos);

            return dtos;
        }

        public async Task<bool> Existe(EventoDto dto)
        {
            Expression<Func<Dominio.Entidades.Evento, bool>> filtro = x =>
                x.EmpresaId == dto.EmpresaId && x.Fecha == dto.Fecha && x.Nombre.Equals(dto.Nombre) &&
                x.EstalecimientoId == dto.EstalecimientoId && !x.EstaEliminado;

            if (dto.Id != 0)
            {
                filtro = x =>
                    x.Id != dto.Id && x.EmpresaId == dto.EmpresaId && x.Fecha == dto.Fecha &&
                    x.Nombre.Equals(dto.Nombre) && x.EstalecimientoId == dto.EstalecimientoId && !x.EstaEliminado;
            }

            var eventos = await _eventoRepositorio.ObtenerFiltrado(filtro);

            return eventos.Any();
        }
    }
}
