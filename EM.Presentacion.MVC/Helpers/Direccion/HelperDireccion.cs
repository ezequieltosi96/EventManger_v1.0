using System.Threading.Tasks;
using EM.IServicio.Direccion;
using EM.IServicio.Direccion.Dto;
using EM.Presentacion.MVC.Models.Direccion;

namespace EM.Presentacion.MVC.Helpers.Direccion
{
    public class HelperDireccion : IHelperDireccion
    {
        private readonly IDireccionServicio _direccionServicio;

        public HelperDireccion(IDireccionServicio direccionServicio)
        {
            _direccionServicio = direccionServicio;
        }

        public async Task<long?> ExisteDireccion(DireccionViewModel model)
        {
            var direccionId = await _direccionServicio.ExisteDireccion(model.LocalidadId, model.Descripcion);

            return direccionId;
        }

        public async Task<long> NuevaDireccion(DireccionViewModel model)
        {
            var dto = new DireccionDto()
            {
                Descripcion = model.Descripcion,
                LocalidadId = model.LocalidadId,
            };

            await _direccionServicio.Insertar(dto);

            var id = (await ExisteDireccion(model)).Value;

            return id;
        }

        public async Task<DireccionViewModel> ObtenerDireccion(long id)
        {
            var dto = (DireccionDto)await _direccionServicio.Obtener(id);

            var model = new DireccionViewModel()
            {
                Id = dto.Id,
                EstaEliminado = dto.EliminadoStr,
                Descripcion = dto.Descripcion,
                LocalidadId = dto.LocalidadId,
            };

            return model;
        }
    }
}
