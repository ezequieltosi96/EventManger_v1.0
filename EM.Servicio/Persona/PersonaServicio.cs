namespace EM.Servicio.Persona
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Persona;
    using EM.IServicio.Persona;
    using EM.IServicio.Persona.Dto;
    using EM.ServicioBase.Dto;

    public class PersonaServicio : IPersonaServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio;
        private readonly IMapper _mapper;

        public PersonaServicio(IPersonaRepositorio personaRepositorio, IMapper mapper)
        {
            _personaRepositorio = personaRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (PersonaDto)dtoBase;

            var persona = _mapper.Map<Dominio.Entidades.Persona>(dto);

            await _personaRepositorio.Insertar(persona);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (PersonaDto)dtoBase;

            var persona = _mapper.Map<Dominio.Entidades.Persona>(dto);

            await _personaRepositorio.Actualizar(persona);
        }

        public async Task Eliminar(long id)
        {
            await _personaRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var persona = await _personaRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<PersonaDto>(persona);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Persona, bool>> filtro = x =>
                x.Nombre.Contains(cadenaBuscar) || x.Apellido.Contains(cadenaBuscar) || x.Dni.Equals(cadenaBuscar) &&
                (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var personas = await _personaRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<PersonaDto>>(personas);

            return dtos;
        }
    }
}
