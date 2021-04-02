namespace EM.Servicio.Rol
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Rol;
    using EM.IServicio.Rol;
    using EM.IServicio.Rol.Dto;
    using EM.ServicioBase.Dto;

    public class RolServicio : IRolServicio
    {
        private readonly IRolRepositorio _rolRepositorio;
        private readonly IMapper _mapper;

        public RolServicio(IRolRepositorio rolRepositorio, IMapper mapper)
        {
            _rolRepositorio = rolRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (RolDto)dtoBase;

            var rol = _mapper.Map<Dominio.Entidades.Rol>(dto);

            await _rolRepositorio.Insertar(rol);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (RolDto)dtoBase;

            var rol = _mapper.Map<Dominio.Entidades.Rol>(dto);

            await _rolRepositorio.Actualizar(rol);
        }

        public async Task Eliminar(long id)
        {
            await _rolRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var rol = await _rolRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<RolDto>(rol);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Rol, bool>> filtro = x =>
                x.Nombre.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var roles = await _rolRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<RolDto>>(roles);

            return dtos;
        }
    }
}
