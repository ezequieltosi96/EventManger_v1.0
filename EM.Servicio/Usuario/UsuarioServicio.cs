using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using EM.Dominio.Repositorio.Usuario;
using EM.IServicio.Usuario;
using EM.IServicio.Usuario.Dto;
using EM.ServicioBase.Dto;

namespace EM.Servicio.Usuario
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (UsuarioDto)dtoBase;

            var usuario = _mapper.Map<Dominio.Entidades.Usuario>(dto);

            await _usuarioRepositorio.Insertar(usuario);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (UsuarioDto)dtoBase;

            var usuario = _mapper.Map<Dominio.Entidades.Usuario>(dto);

            await _usuarioRepositorio.Actualizar(usuario);
        }

        public async Task Eliminar(long id)
        {
            await _usuarioRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var usuario = await _usuarioRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<UsuarioDto>(usuario);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Usuario, bool>> filtro = x => x.Mail.Equals(cadenaBuscar);

            var usuarios = await _usuarioRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);

            return dtos;
        }
    }
}
