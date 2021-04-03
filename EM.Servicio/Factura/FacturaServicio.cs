using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Servicio.Factura
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Factura;
    using EM.IServicio.Factura;
    using EM.IServicio.Factura.Dto;
    using EM.ServicioBase.Dto;

    public class FacturaServicio : IFacturaServicio
    {
        private readonly IFacturaRepositorio _facturaRepositorio;
        private readonly IMapper _mapper;

        public FacturaServicio(IFacturaRepositorio facturaRepositorio, IMapper mapper)
        {
            _facturaRepositorio = facturaRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (FacturaDto)dtoBase;

            var factura = _mapper.Map<Dominio.Entidades.Factura>(dto);

            await _facturaRepositorio.Insertar(factura);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (FacturaDto)dtoBase;

            var factura = _mapper.Map<Dominio.Entidades.Factura>(dto);

            await _facturaRepositorio.Actualizar(factura);
        }

        public async Task Eliminar(long id)
        {
            await _facturaRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var factura = await _facturaRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<FacturaDto>(factura);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Factura, bool>> filtro = x =>
                (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var facturas = await _facturaRepositorio.ObtenerFiltrado(filtro, null);

            var dtos = _mapper.Map<IEnumerable<FacturaDto>>(facturas);

            return dtos;
        }
    }
}
