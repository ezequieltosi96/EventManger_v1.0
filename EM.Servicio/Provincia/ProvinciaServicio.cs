namespace EM.Servicio.Provincia
{
    using System.Linq;
    using System.Linq.Expressions;
    using AutoMapper;
    using EM.Dominio.Repositorio.Provincia;
    using EM.IServicio.Provincia.Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EM.IServicio.Provincia;
    using EM.ServicioBase.Dto;

    public class ProvinciaServicio : IProvinciaServicio
    {
        private readonly IProvinciaRepositorio _provinciaRepositorio;
        private readonly IMapper _mapper;

        public ProvinciaServicio(IProvinciaRepositorio provinciaRepositorio, IMapper mapper)
        {
            _provinciaRepositorio = provinciaRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (ProvinciaDto)dtoBase;

            var provincia = _mapper.Map<Dominio.Entidades.Provincia>(dto);

            await _provinciaRepositorio.Insertar(provincia);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (ProvinciaDto)dtoBase;

            var provincia = _mapper.Map<Dominio.Entidades.Provincia>(dto);

            await _provinciaRepositorio.Actualizar(provincia);
        }

        public async Task Eliminar(long id)
        {
            await _provinciaRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var provincia = await _provinciaRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<ProvinciaDto>(provincia);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Provincia, bool>> filtro = x => x.Nombre.Contains(cadenaBuscar) && !x.EstaEliminado;

            if (mostrarTodos)
            {
                filtro = x => x.Nombre.Contains(cadenaBuscar);
            }

            var provincias = await _provinciaRepositorio.ObtenerFiltrado(filtro, x => x.OrderBy(p => p.Pais.Nombre).ThenBy(p => p.Nombre));

            var dtos = _mapper.Map<IEnumerable<ProvinciaDto>>(provincias);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerPorPais(long id)
        {
            Expression<Func<Dominio.Entidades.Provincia, bool>> filtro = x => x.PaisId == id && !x.EstaEliminado;

            var provincias = await _provinciaRepositorio.ObtenerFiltrado(filtro, x => x.OrderBy(p => p.Pais.Nombre).ThenBy(p => p.Nombre));

            var dtos = _mapper.Map<IEnumerable<ProvinciaDto>>(provincias);

            return dtos;
        }
    }
}
