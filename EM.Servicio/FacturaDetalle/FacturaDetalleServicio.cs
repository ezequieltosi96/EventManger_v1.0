namespace EM.Servicio.FacturaDetalleDetalle
{
    using AutoMapper;
    using EM.Dominio.Repositorio.FacturaDetalle;
    using EM.IServicio.FacturaDetalle;
    using EM.IServicio.FacturaDetalle.Dto;
    using EM.ServicioBase.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class FacturaDetalleServicio : IFacturaDetalleServicio
    {
        private readonly IFacturaDetalleRepositorio _facturaDetalleRepositorio;
        private readonly IMapper _mapper;

        public FacturaDetalleServicio(IFacturaDetalleRepositorio facturaDetalleRepositorio, IMapper mapper)
        {
            _facturaDetalleRepositorio = facturaDetalleRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (FacturaDetalleDto)dtoBase;

            var facturaDetalle = _mapper.Map<Dominio.Entidades.FacturaDetalle>(dto);

            await _facturaDetalleRepositorio.Insertar(facturaDetalle);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (FacturaDetalleDto)dtoBase;

            var facturaDetalle = _mapper.Map<Dominio.Entidades.FacturaDetalle>(dto);

            await _facturaDetalleRepositorio.Actualizar(facturaDetalle);
        }

        public async Task Eliminar(long id)
        {
            await _facturaDetalleRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var facturaDetalle = await _facturaDetalleRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<FacturaDetalleDto>(facturaDetalle);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.FacturaDetalle, bool>> filtro = x =>
                (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var facturaDetalles = await _facturaDetalleRepositorio.ObtenerFiltrado(filtro, null);

            var dtos = _mapper.Map<IEnumerable<FacturaDetalleDto>>(facturaDetalles);

            return dtos;
        }
    }
}
