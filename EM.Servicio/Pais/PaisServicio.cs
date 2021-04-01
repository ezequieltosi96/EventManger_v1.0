using AutoMapper;

namespace EM.Servicio.Pais
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using EM.Dominio.Repositorio;
    using EM.IServicio.Pais;
    using EM.IServicio.Pais.Dto;
    using EM.ServicioBase.Dto;

    public class PaisServicio : IPaisServicio
    {
        private readonly IPaisRepositorio _paisRepositorio;
        private readonly IMapper _mapper;

        public PaisServicio(IPaisRepositorio paisRepositorio, IMapper mapper)
        {
            _paisRepositorio = paisRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (PaisDto)dtoBase;

            var pais = _mapper.Map<Dominio.Entidades.Pais>(dto);

            await _paisRepositorio.Insertar(pais);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (PaisDto)dtoBase;

            var pais = _mapper.Map<Dominio.Entidades.Pais>(dto);

            await _paisRepositorio.Actualizar(pais);
        }

        public async Task Eliminar(long id)
        {
            await _paisRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var pais = await _paisRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<PaisDto>(pais);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Pais, bool>> filtro = x => x.Nombre.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var paises = await _paisRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<PaisDto>>(paises);

            return dtos;
        }
    }
}
