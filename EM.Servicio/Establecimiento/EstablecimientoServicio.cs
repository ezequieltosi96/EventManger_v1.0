using EM.IServicio.Direccion;
using System.Linq;

namespace EM.Servicio.Establecimiento
{
    using AutoMapper;
    using EM.Dominio.Repositorio.Establecimiento;
    using EM.IServicio.Establecimiento;
    using EM.IServicio.Establecimiento.Dto;
    using EM.ServicioBase.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class EstablecimientoServicio : IEstablecimientoServicio
    {
        private readonly IDireccionServicio _direccionServicio;
        private readonly IEstablecimientoRepositorio _establecimientoRepositorio;
        private readonly IMapper _mapper;

        public EstablecimientoServicio(IDireccionServicio direccionServicio, IEstablecimientoRepositorio establecimientoRepositorio, IMapper mapper)
        {
            _direccionServicio = direccionServicio;
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
                x.Nombre.Contains(cadenaBuscar) && !x.EstaEliminado;

            if (mostrarTodos)
                filtro = x =>
                    x.Nombre.Contains(cadenaBuscar);

            var establecimientos = await _establecimientoRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<EstablecimientoDto>>(establecimientos);

            return dtos;
        }

        public async Task<bool> Existe(string nombre, string direccionDescripcion, long direccionLocalidadId)
        {
            var establecimientosporNombre = (IEnumerable<EstablecimientoDto>)await Obtener(nombre);

            if (!establecimientosporNombre.Any()) return false;

            var direccionId = await _direccionServicio.ExisteDireccion(direccionLocalidadId, direccionDescripcion);

            if (!direccionId.HasValue) return false;

            if (!establecimientosporNombre.Any(e => e.DireccionId == direccionId)) return false;

            return true;
        }

        public async Task<bool> Existe(string nombre, string direccionDescripcion, long direccionLocalidadId, long id)
        {
            var establecimientosporNombre = (IEnumerable<EstablecimientoDto>)await Obtener(nombre);

            if (!establecimientosporNombre.Any()) return false;

            var direccionId = await _direccionServicio.ExisteDireccion(direccionLocalidadId, direccionDescripcion);

            if (!direccionId.HasValue) return false;

            var est = establecimientosporNombre.FirstOrDefault(e => e.DireccionId == direccionId);

            if (est == null) return false;

            if (est.Id == id) return false;

            return true;
        }
    }
}
