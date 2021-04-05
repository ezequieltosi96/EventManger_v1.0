using System.Linq;

namespace EM.Servicio.Disertante
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Disertante;
    using EM.IServicio.Disertante;
    using EM.IServicio.Disertante.Dto;
    using EM.ServicioBase.Dto;

    public class DisertanteServicio : IDisertanteServicio
    {
        private readonly IDisertanteRepositorio _disertanteRepositorio;
        private readonly IMapper _mapper;

        public DisertanteServicio(IDisertanteRepositorio disertanteRepositorio, IMapper mapper)
        {
            _disertanteRepositorio = disertanteRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (DisertanteDto)dtoBase;

            var disertante = _mapper.Map<Dominio.Entidades.Disertante>(dto);

            await _disertanteRepositorio.Insertar(disertante);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (DisertanteDto)dtoBase;

            var disertante = _mapper.Map<Dominio.Entidades.Disertante>(dto);

            await _disertanteRepositorio.Actualizar(disertante);
        }

        public async Task Eliminar(long id)
        {
            await _disertanteRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var disertante = await _disertanteRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<DisertanteDto>(disertante);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Disertante, bool>> filtro = x =>
                (x.Nombre.Contains(cadenaBuscar) || x.Apellido.Contains(cadenaBuscar) || x.Dni.Equals(cadenaBuscar)) && !x.EstaEliminado;

            if (mostrarTodos)
                filtro = x =>
                    (x.Nombre.Contains(cadenaBuscar) || x.Apellido.Contains(cadenaBuscar) ||
                     x.Dni.Equals(cadenaBuscar));

            var disertantes = await _disertanteRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<DisertanteDto>>(disertantes);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerPorEmpresa(long empresaId, string cadenaBuscar = "", bool mostarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Disertante, bool>> filtro = x => x.EmpresaId == empresaId &&
                (x.Nombre.Contains(cadenaBuscar) || x.Apellido.Contains(cadenaBuscar) || x.Dni.Equals(cadenaBuscar)) && !x.EstaEliminado;

            if (mostarTodos)
                filtro = x => x.EmpresaId == empresaId &&
                              (x.Nombre.Contains(cadenaBuscar) || x.Apellido.Contains(cadenaBuscar) || x.Dni.Equals(cadenaBuscar));

            var disertantes = await _disertanteRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<DisertanteDto>>(disertantes);

            return dtos;
        }
    }
}
