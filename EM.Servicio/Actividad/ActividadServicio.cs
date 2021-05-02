using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EM.Servicio.Actividad
{
    using AutoMapper;
    using EM.Dominio.Repositorio.Actividad;
    using EM.IServicio.Actividad;
    using EM.IServicio.Actividad.Dto;
    using EM.ServicioBase.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class ActividadServicio : IActividadServicio
    {
        private readonly IActividadRepositorio _actividadRepositorio;
        private readonly IMapper _mapper;

        public ActividadServicio(IActividadRepositorio actividadRepositorio, IMapper mapper)
        {
            _actividadRepositorio = actividadRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (ActividadDto)dtoBase;

            var actividad = _mapper.Map<Dominio.Entidades.Actividad>(dto);

            await _actividadRepositorio.Insertar(actividad);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (ActividadDto)dtoBase;

            var actividad = _mapper.Map<Dominio.Entidades.Actividad>(dto);

            await _actividadRepositorio.Actualizar(actividad);
        }

        public async Task Eliminar(long id)
        {
            await _actividadRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var actividad = await _actividadRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<ActividadDto>(actividad);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Actividad, bool>> filtro = x =>
                x.Nombre.Contains(cadenaBuscar) && !x.EstaEliminado;

            if (mostrarTodos)
            {
                filtro = x =>
                    x.Nombre.Contains(cadenaBuscar);
            }

            var actividades = await _actividadRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<ActividadDto>>(actividades);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerPorSalaYFecha(long salaId, DateTime fecha, long? eventoId = null)
        {
            Expression<Func<Dominio.Entidades.Actividad, bool>> filtro = x =>
                x.SalaId == salaId && x.FechaHora.Date == fecha.Date && !x.EstaEliminado;

            if (eventoId.HasValue)
            {
                filtro = x => x.EventoId != eventoId.Value && x.SalaId == salaId && x.FechaHora.Date == fecha.Date && !x.EstaEliminado;
            }

            var actividades = await _actividadRepositorio.ObtenerFiltrado(filtro,
                x => x.OrderBy(a => a.Evento.Nombre).ThenBy(a => a.Nombre), x => x.Include(a => a.Evento));

            var dtos = _mapper.Map<IEnumerable<ActividadDto>>(actividades);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerPorDisertanteYFecha(long disertanteId, DateTime fecha)
        {
            Expression<Func<Dominio.Entidades.Actividad, bool>> filtro = x =>
                x.DisertanteId == disertanteId && x.FechaHora.Date == fecha.Date && !x.EstaEliminado;

            //if (eventoId.HasValue)
            //{
            //    filtro = x => x.EventoId != eventoId.Value && x.SalaId == salaId && x.FechaHora.Date == fecha.Date && !x.EstaEliminado;
            //}

            var actividades = await _actividadRepositorio.ObtenerFiltrado(filtro,
                x => x.OrderBy(a => a.Evento.Nombre).ThenBy(a => a.Nombre), x => x.Include(a => a.Evento));

            var dtos = _mapper.Map<IEnumerable<ActividadDto>>(actividades);

            return dtos;
        }

        public async Task<bool> DisertanteEstaDisponible(long disertanteId, DateTime fecha)
        {
            Expression<Func<Dominio.Entidades.Actividad, bool>> filtro = x =>
                x.DisertanteId == disertanteId && x.FechaHora.Date == fecha.Date && !x.EstaEliminado;

            var actividades = await _actividadRepositorio.ObtenerFiltrado(filtro);

            return !actividades.Any();
        }

        public async Task<bool> SalaEstaDisponible(long salaId, DateTime fecha)
        {
            Expression<Func<Dominio.Entidades.Actividad, bool>> filtro = x =>
                x.SalaId == salaId && x.FechaHora.Date == fecha.Date && !x.EstaEliminado;

            var actividades = await _actividadRepositorio.ObtenerFiltrado(filtro);

            return !actividades.Any();
        }

        public async Task<bool> Existe(string nombre, long eventoId)
        {
            Expression<Func<Dominio.Entidades.Actividad, bool>> filtro = x =>
                x.Nombre.Equals(nombre) && x.EventoId == eventoId && !x.EstaEliminado;

            var actividades = await _actividadRepositorio.ObtenerFiltrado(filtro);

            return actividades.Any();
        }
    }
}
