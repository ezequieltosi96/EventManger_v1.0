using System.Linq;

namespace EM.Servicio.Direccion
{
    using AutoMapper;
    using EM.Dominio.Repositorio.Direccion;
    using EM.IServicio.Direccion;
    using EM.IServicio.Direccion.Dto;
    using EM.ServicioBase.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class DireccionServicio : IDireccionServicio
    {
        private readonly IDireccionRepositorio _direccionRepositorio;
        private readonly IMapper _mapper;

        public DireccionServicio(IDireccionRepositorio direccionRepositorio, IMapper mapper)
        {
            _direccionRepositorio = direccionRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (DireccionDto)dtoBase;

            var direccion = _mapper.Map<Dominio.Entidades.Direccion>(dto);

            await _direccionRepositorio.Insertar(direccion);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (DireccionDto)dtoBase;

            var direccion = _mapper.Map<Dominio.Entidades.Direccion>(dto);

            await _direccionRepositorio.Actualizar(direccion);
        }

        public async Task Eliminar(long id)
        {
            await _direccionRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var direccion = await _direccionRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<DireccionDto>(direccion);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Direccion, bool>> filtro = x =>
                x.Descripcion.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var direcciones = await _direccionRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<DireccionDto>>(direcciones);

            return dtos;
        }

        public async Task<long?> ExisteDireccion(long localidadId, string descripcion)
        {
            Expression<Func<Dominio.Entidades.Direccion, bool>> filtro = x =>
                x.LocalidadId == localidadId && x.Descripcion.Equals(descripcion);

            var direcciones = await _direccionRepositorio.ObtenerFiltrado(filtro);

            var direccion =
                direcciones.FirstOrDefault(d => d.LocalidadId == localidadId && d.Descripcion.Equals(descripcion));

            return direccion?.Id;
        }
    }
}
