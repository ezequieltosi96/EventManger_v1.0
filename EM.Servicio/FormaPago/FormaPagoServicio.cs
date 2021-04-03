using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Servicio.FormaPago
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.FormaPago;
    using EM.IServicio.FormaPago;
    using EM.IServicio.FormaPago.Dto;
    using EM.ServicioBase.Dto;

    public class FormaPagoServicio : IFormaPagoServicio
    {
        private readonly IFormaPagoRepositorio _formaPagoRepositorio;
        private readonly IMapper _mapper;

        public FormaPagoServicio(IFormaPagoRepositorio formaPagoRepositorio, IMapper mapper)
        {
            _formaPagoRepositorio = formaPagoRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (FormaPagoDto)dtoBase;

            var formaPago = _mapper.Map<Dominio.Entidades.FormaPago>(dto);

            await _formaPagoRepositorio.Insertar(formaPago);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (FormaPagoDto)dtoBase;

            var formaPago = _mapper.Map<Dominio.Entidades.FormaPago>(dto);

            await _formaPagoRepositorio.Actualizar(formaPago);
        }

        public async Task Eliminar(long id)
        {
            await _formaPagoRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var formaPago = await _formaPagoRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<FormaPagoDto>(formaPago);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.FormaPago, bool>> filtro = x =>
              x.Nombre.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var formaPagos = await _formaPagoRepositorio.ObtenerFiltrado(filtro, null);

            var dtos = _mapper.Map<IEnumerable<FormaPagoDto>>(formaPagos);

            return dtos;
        }
    }
}
