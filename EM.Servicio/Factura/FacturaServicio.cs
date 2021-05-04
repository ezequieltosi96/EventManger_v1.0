using System.Linq;

namespace EM.Servicio.Factura
{
    using AutoMapper;
    using EM.Dominio.Repositorio.Factura;
    using EM.IServicio.Factura;
    using EM.IServicio.Factura.Dto;
    using EM.ServicioBase.Dto;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

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
            var factura = await _facturaRepositorio.ObtenerPorId(id, f => f.Include(e => e.FacturaDetalles));

            var dto = _mapper.Map<FacturaDto>(factura);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Factura, bool>> filtro = x => !x.EstaEliminado;

            if (mostrarTodos)
            {
                filtro = x => x.EstaEliminado || !x.EstaEliminado;
            }
            var facturas = await _facturaRepositorio.ObtenerFiltrado(filtro, null, f => f.Include(e => e.FacturaDetalles));

            var dtos = _mapper.Map<IEnumerable<FacturaDto>>(facturas);

            return dtos;
        }

        public async Task<long> InsertarDevuelveId(DtoBase dtoBase)
        {
            var dto = (FacturaDto)dtoBase;

            var factura = _mapper.Map<Dominio.Entidades.Factura>(dto);

            await _facturaRepositorio.Insertar(factura);

            return factura.Id;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerPorCliente(long clienteId)
        {
            Expression<Func<Dominio.Entidades.Factura, bool>> filtro = x => x.ClienteId == clienteId && !x.EstaEliminado;

            var facturas = await _facturaRepositorio.ObtenerFiltrado(filtro, null, f => f.Include(e => e.FacturaDetalles));

            var dtos = _mapper.Map<IEnumerable<FacturaDto>>(facturas);

            return dtos;
        }

        public async Task<IEnumerable<DtoBase>> ObtenerPorEmpresa(long empresaId, string cadenaBuscar = "", bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Factura, bool>> filtro = x => x.EmpresaId == empresaId && !x.EstaEliminado;

            if (mostrarTodos)
            {
                filtro = x => x.EmpresaId == empresaId && (x.EstaEliminado || !x.EstaEliminado);
            }
            var facturas = await _facturaRepositorio.ObtenerFiltrado(filtro, null, f => f.Include(e => e.FacturaDetalles));

            var dtos = _mapper.Map<IEnumerable<FacturaDto>>(facturas);

            return dtos;
        }
    }
}
