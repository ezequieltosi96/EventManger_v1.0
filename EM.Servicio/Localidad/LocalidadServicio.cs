using System.Linq;

namespace EM.Servicio.Localidad
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Localidad;
    using EM.IServicio.Localidad;
    using EM.IServicio.Localidad.Dto;
    using EM.ServicioBase.Dto;
    public class LocalidadServicio : ILocalidadServicio
    {
        private readonly ILocalidadRepositorio _localidadRepositorio;
        private readonly IMapper _mapper;

        public LocalidadServicio(ILocalidadRepositorio localidadRepositorio, IMapper mapper)
        {
            _localidadRepositorio = localidadRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (LocalidadDto)dtoBase;

            var localidad = _mapper.Map<Dominio.Entidades.Localidad>(dto);

            await _localidadRepositorio.Insertar(localidad);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (LocalidadDto)dtoBase;

            var localidad = _mapper.Map<Dominio.Entidades.Localidad>(dto);

            await _localidadRepositorio.Actualizar(localidad);
        }

        public async Task Eliminar(long id)
        {
            await _localidadRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var localidad = await _localidadRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<LocalidadDto>(localidad);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Localidad, bool>> filtro = x => x.Nombre.Contains(cadenaBuscar) && !x.EstaEliminado;

            if (mostrarTodos)
            {
                filtro = x => x.Nombre.Contains(cadenaBuscar);
            }

            var localidades = await _localidadRepositorio.ObtenerFiltrado(filtro, x => x.OrderBy(l => l.Provincia.Nombre).ThenBy(l => l.Nombre));

            var dtos = _mapper.Map<IEnumerable<LocalidadDto>>(localidades);

            return dtos;
        }
    }
}
