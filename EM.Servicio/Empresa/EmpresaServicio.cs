using System.Linq;

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
                (x.RazonSocial.Contains(cadenaBuscar) || x.NombreFantasia.Contains(cadenaBuscar) ||
                x.Cuil.Equals(cadenaBuscar)) && !x.EstaEliminado;

            if (mostrarTodos)
            {
                filtro = x =>
                    x.RazonSocial.Contains(cadenaBuscar) || x.NombreFantasia.Contains(cadenaBuscar) ||
                    x.Cuil.Equals(cadenaBuscar);
            }

            var empresas = await _empresaRepositorio.ObtenerFiltrado(filtro, x => x.OrderBy(e => e.RazonSocial).ThenBy(e => e.NombreFantasia));

            var dtos = _mapper.Map<IEnumerable<EmpresaDto>>(empresas);

            return dtos;
        }

        public async Task<DtoBase> ObtenerPorEmail(string email)
        {
            Expression<Func<Dominio.Entidades.Empresa, bool>> filtro = x => x.Email.Equals(email);

            var empresas = await _empresaRepositorio.ObtenerFiltrado(filtro);

            var empresa = empresas.First(e => e.Email.Equals(email));

            var dto = _mapper.Map<EmpresaDto>(empresa);

            return dto;
        }

        public async Task<bool> Existe(string cuil, string razonSocial)
        {
            Expression<Func<Dominio.Entidades.Empresa, bool>> filtro = x =>
                x.Cuil.Equals(cuil) && x.RazonSocial.Equals(razonSocial);

            var empresas = await _empresaRepositorio.ObtenerFiltrado(filtro);

            return empresas.Any();
        }
    }
}
