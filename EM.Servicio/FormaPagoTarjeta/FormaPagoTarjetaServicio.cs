namespace EM.Servicio.FormaPagoTarjetaTarjeta
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.FormaPagoTarjeta;
    using EM.IServicio.FormaPagoTarjeta;
    using EM.IServicio.FormaPagoTarjeta.Dto;
    using EM.ServicioBase.Dto;

    public class FormaPagoTarjetaServicio : IFormaPagoTarjetaServicio
    {
        private readonly IFormaPagoTarjetaRepositorio _formaPagoTarjetaRepositorio;
        private readonly IMapper _mapper;

        public FormaPagoTarjetaServicio(IFormaPagoTarjetaRepositorio formaPagoTarjetaRepositorio, IMapper mapper)
        {
            _formaPagoTarjetaRepositorio = formaPagoTarjetaRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (FormaPagoTarjetaDto)dtoBase;

            var formaPagoTarjeta = _mapper.Map<Dominio.Entidades.FormaPagoTarjeta>(dto);

            await _formaPagoTarjetaRepositorio.Insertar(formaPagoTarjeta);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (FormaPagoTarjetaDto)dtoBase;

            var formaPagoTarjeta = _mapper.Map<Dominio.Entidades.FormaPagoTarjeta>(dto);

            await _formaPagoTarjetaRepositorio.Actualizar(formaPagoTarjeta);
        }

        public async Task Eliminar(long id)
        {
            await _formaPagoTarjetaRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var formaPagoTarjeta = await _formaPagoTarjetaRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<FormaPagoTarjetaDto>(formaPagoTarjeta);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.FormaPagoTarjeta, bool>> filtro = x =>
              x.Nombre.Contains(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var formaPagoTarjetas = await _formaPagoTarjetaRepositorio.ObtenerFiltrado(filtro, null);

            var dtos = _mapper.Map<IEnumerable<FormaPagoTarjetaDto>>(formaPagoTarjetas);

            return dtos;
        }
    }
}
