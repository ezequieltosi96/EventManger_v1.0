namespace EM.Servicio.Empresa
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using AutoMapper;
    using EM.Dominio.Repositorio.Empresa;
    using EM.IServicio.Empresa;
    using EM.IServicio.Empresa.Dto;
    using EM.ServicioBase.Dto;

    public class EmpresaServicio : IEmpresaServicio
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly IMapper _mapper;
        public EmpresaServicio(IEmpresaRepositorio empresaRepositorio, IMapper mapper)
        {
            _empresaRepositorio = empresaRepositorio;
            _mapper = mapper;
        }

        public async Task Insertar(DtoBase dtoBase)
        {
            var dto = (EmpresaDto)dtoBase;

            var empresa = _mapper.Map<Dominio.Entidades.Empresa>(dto);

            await _empresaRepositorio.Insertar(empresa);
        }

        public async Task Modificar(DtoBase dtoBase)
        {
            var dto = (EmpresaDto)dtoBase;

            var empresa = _mapper.Map<Dominio.Entidades.Empresa>(dto);

            await _empresaRepositorio.Actualizar(empresa);
        }

        public async Task Eliminar(long id)
        {
            await _empresaRepositorio.Eliminar(id);
        }

        public async Task<DtoBase> Obtener(long id)
        {
            var empresa = await _empresaRepositorio.ObtenerPorId(id);

            var dto = _mapper.Map<EmpresaDto>(empresa);

            return dto;
        }

        public async Task<IEnumerable<DtoBase>> Obtener(string cadenaBuscar, bool mostrarTodos = true)
        {
            Expression<Func<Dominio.Entidades.Empresa, bool>> filtro = x =>
                x.RazonSocial.Contains(cadenaBuscar) || x.NombreFantasia.Contains(cadenaBuscar) ||
                x.Cuil.Equals(cadenaBuscar) && (mostrarTodos ? !x.EstaEliminado : x.EstaEliminado);

            var empresas = await _empresaRepositorio.ObtenerFiltrado(filtro);

            var dtos = _mapper.Map<IEnumerable<EmpresaDto>>(empresas);

            return dtos;
        }
    }
}
