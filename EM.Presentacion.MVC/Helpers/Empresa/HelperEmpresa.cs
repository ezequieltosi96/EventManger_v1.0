using System.Threading.Tasks;
using EM.IServicio.Empresa;
using EM.IServicio.Empresa.Dto;
using EM.Presentacion.MVC.Models.Empresa;

namespace EM.Presentacion.MVC.Helpers.Empresa
{
    public class HelperEmpresa : IHelperEmpresa
    {
        private readonly IEmpresaServicio _empresaServicio;

        public HelperEmpresa(IEmpresaServicio empresaServicio)
        {
            _empresaServicio = empresaServicio;
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
    }
}
