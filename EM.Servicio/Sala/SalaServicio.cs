namespace EM.Servicio.Sala
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Sala;
    using EM.IServicio.Sala;
    using EM.IServicio.Sala.Dto;
    using EM.ServicioBase.Dto;

    public class SalaServicio : ISalaServicio
    {
        private readonly ISalaRespositorio _salaRespositorio;
        private readonly IMapper _mapper;

        public SalaServicio(ISalaRespositorio salaRespositorio, IMapper mapper)
        {
            _salaRespositorio = salaRespositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (SalaDto)dtoBase;

            var sala = _mapper.Map<Dominio.Entidades.Sala>(dto);

            await _salaRespositorio.Insertar(sala);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (SalaDto)dtoBase;

            var sala = _mapper.Map<Dominio.Entidades.Sala>(dto);

            await _salaRespositorio.Actualizar(sala);
        }

        public async Task Eliminar(long id)
        {
            await _salaRespositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var sala = await _salaRespositorio.ObtenerPorId(id);

            var dto = _mapper.Map<SalaDto>(sala);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Sala, bool>> filtro = x =>
                x.Nombre.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var salas = await _salaRespositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<SalaDto>>(salas);

            return dtos;
        }
    }
}
