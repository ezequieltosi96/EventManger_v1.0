namespace EM.Servicio.Inscripcion
{
    using AutoMapper;
    using EM.Dominio.Repositorio.Inscripcion;
    using EM.IServicio.Inscripcion;
    using EM.IServicio.Inscripcion.Dto;
    using EM.ServicioBase.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class InscripcionServicio : IInscripcionServicio
    {
        private readonly IInscripcionRepositorio _inscripcionRepositorio;
        private readonly IMapper _mapper;

        public InscripcionServicio(IInscripcionRepositorio inscripcionRepositorio, IMapper mapper)
        {
            _inscripcionRepositorio = inscripcionRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (InscripcionDto)dtoBase;

            var inscripcion = _mapper.Map<Dominio.Entidades.Inscripcion>(dto);

            await _inscripcionRepositorio.Insertar(inscripcion);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (InscripcionDto)dtoBase;

            var inscripcion = _mapper.Map<Dominio.Entidades.Inscripcion>(dto);

            await _inscripcionRepositorio.Actualizar(inscripcion);
        }

        public async Task Eliminar(long id)
        {
            await _inscripcionRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var inscripcion = await _inscripcionRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<InscripcionDto>(inscripcion);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {

            Expression<Func<Dominio.Entidades.Inscripcion, bool>> filtro = x =>
            (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var inscripciones = await _inscripcionRepositorio.ObtenerFiltrado(filtro, null);

            var dtos = _mapper.Map<IEnumerable<InscripcionDto>>(inscripciones);

            return dtos;
        }
    }
}
