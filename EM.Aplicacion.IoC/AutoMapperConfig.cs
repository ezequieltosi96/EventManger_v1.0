using EM.IServicio.Provincia.Dto;

namespace EM.Aplicacion.IoC
{
    using AutoMapper;
    using EM.Dominio.Entidades;
    using EM.IServicio.Pais.Dto;

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
        }
    }
}
