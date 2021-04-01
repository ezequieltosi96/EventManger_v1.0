namespace EM.Servicio.BeneficioEntrada
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.BeneficioEntrada;
    using EM.IServicio.BeneficioEntrada;
    using EM.IServicio.BeneficioEntrada.Dto;
    using EM.ServicioBase.Dto;
    public class BeneficioEntradaServicio : IBeneficioEntradaServicio
    {
        private readonly IBeneficioEntradaRepositorio _beneficioEntradaRepositorio;
        private readonly IMapper _mapper;

        public BeneficioEntradaServicio(IBeneficioEntradaRepositorio beneficioEntradaRepositorio, IMapper mapper)
        {
            _beneficioEntradaRepositorio = beneficioEntradaRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (BeneficioEntradaDto)dtoBase;

            var beneficioEntrada = _mapper.Map<Dominio.Entidades.BeneficioEntrada>(dto);

            await _beneficioEntradaRepositorio.Insertar(beneficioEntrada);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (BeneficioEntradaDto)dtoBase;

            var beneficioEntrada = _mapper.Map<Dominio.Entidades.BeneficioEntrada>(dto);

            await _beneficioEntradaRepositorio.Actualizar(beneficioEntrada);
        }

        public async Task Eliminar(long id)
        {
            await _beneficioEntradaRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var beneficioEntrada = await _beneficioEntradaRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<BeneficioEntradaDto>(beneficioEntrada);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.BeneficioEntrada, bool>> filtro = x => x.Nombre.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var beneficioEntradas = await _beneficioEntradaRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<BeneficioEntradaDto>>(beneficioEntradas);

            return dtos;
        }
    }
}
