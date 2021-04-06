using System.Threading.Tasks;
using EM.Dominio.Identity;
using EM.IServicio.Empresa;
using EM.IServicio.Empresa.Dto;
using EM.Presentacion.MVC.Helpers.Direccion;
using EM.Presentacion.MVC.Models.Empresa;
using Microsoft.AspNetCore.Identity;

namespace EM.Presentacion.MVC.Helpers.Empresa
{
    public class HelperEmpresa : IHelperEmpresa
    {
        private readonly IEmpresaServicio _empresaServicio;
        private readonly IHelperDireccion _helperDireccion;

        public HelperEmpresa(IEmpresaServicio empresaServicio, IHelperDireccion helperDireccion)
        {
            _empresaServicio = empresaServicio;
            _helperDireccion = helperDireccion;
        }

        public async Task<bool> ExisteEmpresa(string cuil, string razonSocial)
        {
            var existe = await _empresaServicio.Existe(cuil, razonSocial);

            return existe;
        }

        public async Task<bool> NuevaEmpresa(EmpresaViewModel model)
        {
            var dto = new EmpresaDto()
            {
                Cuil = model.Cuil,
                DireccionId = model.DireccionId,
                Email = model.Email,
                NombreFantasia = model.NombreFantasia,
                RazonSocial = model.RazonSocial,
            };

            await _empresaServicio.Insertar(dto);

            var existe = await ExisteEmpresa(dto.Cuil, dto.RazonSocial);

            return existe;
        }

        public async Task<EmpresaViewModel> ObtenerEmpresaActual(string email)
        {
            var dto = (EmpresaDto)await _empresaServicio.ObtenerPorEmail(email);

            var direccion = await _helperDireccion.ObtenerDireccion(dto.DireccionId);

            var model = new EmpresaViewModel()
            {
                Id = dto.Id,
                Cuil = dto.Cuil,
                DireccionId = dto.DireccionId,
                Email = dto.Email,
                EstaEliminado = dto.EliminadoStr,
                NombreFantasia = dto.NombreFantasia,
                RazonSocial = dto.RazonSocial,
                Direccion = direccion,
                DireccionStr = direccion.Descripcion
            };

            return model;
        }

        public async Task<EmpresaViewModel> ObtenerEmpresa(long id)
        {
            var dto = (EmpresaDto)await _empresaServicio.Obtener(id);

            if (dto == null) return null;

            var direccion = await _helperDireccion.ObtenerDireccion(dto.DireccionId);

            var model = new EmpresaViewModel()
            {
                Id = dto.Id,
                Cuil = dto.Cuil,
                DireccionId = dto.DireccionId,
                Email = dto.Email,
                EstaEliminado = dto.EliminadoStr,
                NombreFantasia = dto.NombreFantasia,
                RazonSocial = dto.RazonSocial,
                Direccion = direccion,
                DireccionStr = direccion.Descripcion
            };

            return model;
        }
    }
}
