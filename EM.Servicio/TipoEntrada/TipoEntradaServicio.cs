using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Servicio.TipoEntrada
{
    using System.Linq.Expressions;
    using AutoMapper;
    using EM.Dominio.Repositorio.TipoEntrada;
    using EM.IServicio.TipoEntrada.Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EM.IServicio.TipoEntrada;
    using EM.ServicioBase.Dto;

    public class TipoEntradaServicio : ITipoEntradaServicio
    {
        private readonly ITipoEntradaRepositorio _tipoEntradaRepositorio;
        private readonly IMapper _mapper;

        public TipoEntradaServicio(ITipoEntradaRepositorio tipoEntradaRepositorio, IMapper mapper)
        {
            _tipoEntradaRepositorio = tipoEntradaRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (TipoEntradaDto)dtoBase;

            var tipoEntrada = _mapper.Map<Dominio.Entidades.TipoEntrada>(dto);

            await _tipoEntradaRepositorio.Insertar(tipoEntrada);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (TipoEntradaDto)dtoBase;

            var tipoEntrada = _mapper.Map<Dominio.Entidades.TipoEntrada>(dto);

            await _tipoEntradaRepositorio.Actualizar(tipoEntrada);
        }

        public async Task Eliminar(long id)
        {
            await _tipoEntradaRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var tipoEntrada = await _tipoEntradaRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<TipoEntradaDto>(tipoEntrada);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.TipoEntrada, bool>> filtro = x => x.Nombre.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var tipoEntradas = await _tipoEntradaRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<TipoEntradaDto>>(tipoEntradas);

            return dtos;
        }
    }
}
