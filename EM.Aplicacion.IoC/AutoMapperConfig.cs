namespace EM.Aplicacion.IoC
{
    using AutoMapper;
    using EM.Dominio.Entidades;
    using EM.IServicio.Actividad.Dto;
    using EM.IServicio.BeneficioEntrada.Dto;
    using EM.IServicio.Cliente.Dto;
    using EM.IServicio.Direccion.Dto;
    using EM.IServicio.Disertante.Dto;
    using EM.IServicio.Empresa.Dto;
    using EM.IServicio.Entrada.Dto;
    using EM.IServicio.Establecimiento.Dto;
    using EM.IServicio.Evento.Dto;
    using EM.IServicio.Factura.Dto;
    using EM.IServicio.FacturaDetalle.Dto;
    using EM.IServicio.FormaPago.Dto;
    using EM.IServicio.FormaPagoTarjeta.Dto;
    using EM.IServicio.Inscripcion.Dto;
    using EM.IServicio.Localidad.Dto;
    using EM.IServicio.Pais.Dto;
    using EM.IServicio.Persona.Dto;
    using EM.IServicio.Provincia.Dto;
    using EM.IServicio.Sala.Dto;
    using EM.IServicio.TipoEntrada.Dto;

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

            // actividad
            CreateMap<Actividad, ActividadDto>();
            CreateMap<ActividadDto, Actividad>();

            // evento
            CreateMap<Evento, EventoDto>();
            CreateMap<EventoDto, Evento>();

            // Entrada
            CreateMap<Entrada, EntradaDto>();
            CreateMap<EntradaDto, Entrada>();

            //Inscripcion
            CreateMap<Inscripcion, InscripcionDto>();
            CreateMap<InscripcionDto, Inscripcion>();

            //Factura
            CreateMap<Factura, FacturaDto>();
            CreateMap<FacturaDto, Factura>();

            //FacturaDetalle
            CreateMap<FacturaDetalle, FacturaDetalleDto>();
            CreateMap<FacturaDetalleDto, FacturaDetalle>();

            //FormaPago
            CreateMap<FormaPago, FormaPagoDto>();
            CreateMap<FormaPagoDto, FormaPago>();

            //FormaPago
            CreateMap<FormaPagoTarjeta, FormaPagoTarjetaDto>();
            CreateMap<FormaPagoTarjetaDto, FormaPagoTarjeta>();
        }
    }
}
