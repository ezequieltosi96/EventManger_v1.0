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
    using EM.IServicio.Empresa.Dto;
    using EM.IServicio.Disertante.Dto;
    using EM.IServicio.Establecimiento.Dto;
    using EM.IServicio.Sala.Dto;

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

            // cliente
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();

            //TipoEntrada
            CreateMap<TipoEntrada, TipoEntradaDto>();
            CreateMap<TipoEntradaDto, TipoEntrada>();

            // empresa
            CreateMap<Empresa, EmpresaDto>();
            CreateMap<EmpresaDto, Empresa>();

            // disertante 
            CreateMap<Disertante, DisertanteDto>();
            CreateMap<DisertanteDto, Disertante>();

            // establecimiento
            CreateMap<Establecimiento, EstablecimientoDto>();
            CreateMap<EstablecimientoDto, Establecimiento>();

            // sala
            CreateMap<Sala, SalaDto>();
            CreateMap<SalaDto, Sala>();
        }
    }
}
