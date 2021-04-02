namespace EM.Aplicacion.IoC
{
    using AutoMapper;
    using EM.Dominio.Entidades;
    using EM.IServicio.BeneficioEntrada.Dto;
    using EM.IServicio.Pais.Dto;
    using EM.IServicio.Direccion.Dto;
    using EM.IServicio.Localidad.Dto;
    using EM.IServicio.Provincia.Dto;
    using EM.IServicio.TipoEntrada.Dto;
    using EM.IServicio.Cliente.Dto;
    using EM.IServicio.Persona.Dto;
    using EM.IServicio.Rol.Dto;
    using EM.IServicio.Usuario.Dto;

    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // pais
            CreateMap<Pais, PaisDto>();
            CreateMap<PaisDto, Pais>();

            // provincia
            CreateMap<Provincia, ProvinciaDto>();
            CreateMap<ProvinciaDto, Provincia>();

            // localidad
            CreateMap<Localidad, LocalidadDto>();
            CreateMap<LocalidadDto, Localidad>();

            // direccion
            CreateMap<Direccion, DireccionDto>();
            CreateMap<DireccionDto, Direccion>();

            //BeneficioEntrada
            CreateMap<BeneficioEntrada, BeneficioEntradaDto>();
            CreateMap<BeneficioEntradaDto, BeneficioEntrada>();

            // persona
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();

            // rol
            CreateMap<Rol, RolDto>();
            CreateMap<RolDto, Rol>();

            // usuario
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();

            // cliente
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            //TipoEntrada
            CreateMap<TipoEntrada, TipoEntradaDto>();
            CreateMap<TipoEntradaDto, TipoEntrada>();
        }
    }
}
