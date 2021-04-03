namespace EM.Servicio.Establecimiento
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Establecimiento;
    using EM.IServicio.Establecimiento;
    using EM.IServicio.Establecimiento.Dto;
    using EM.ServicioBase.Dto;

    public class EstablecimientoServicio : IEstablecimientoServicio
    {
        private readonly IEstablecimientoRepositorio _establecimientoRepositorio;
        private readonly IMapper _mapper;

        public EstablecimientoServicio(IEstablecimientoRepositorio establecimientoRepositorio, IMapper mapper)
        {
            _establecimientoRepositorio = establecimientoRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (EstablecimientoDto)dtoBase;

            var establecimiento = _mapper.Map<Dominio.Entidades.Establecimiento>(dto);

            await _establecimientoRepositorio.Insertar(establecimiento);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (EstablecimientoDto)dtoBase;

            var establecimiento = _mapper.Map<Dominio.Entidades.Establecimiento>(dto);

            await _establecimientoRepositorio.Actualizar(establecimiento);
        }

        public async Task Eliminar(long id)
        {
            await _establecimientoRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var establecimiento = await _establecimientoRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<EstablecimientoDto>(establecimiento);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Establecimiento, bool>> filtro = x =>
                x.Nombre.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var establecimientos = await _establecimientoRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<EstablecimientoDto>>(establecimientos);

            return dtos;
        }
    }
}
