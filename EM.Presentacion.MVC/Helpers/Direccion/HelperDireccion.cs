using EM.IServicio.Direccion;
using EM.IServicio.Direccion.Dto;
using EM.IServicio.Localidad;
using EM.IServicio.Localidad.Dto;
using EM.IServicio.Pais;
using EM.IServicio.Pais.Dto;
using EM.IServicio.Provincia;
using EM.IServicio.Provincia.Dto;
using EM.Presentacion.MVC.Models.Direccion;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Direccion
{
    public class HelperDireccion : IHelperDireccion
    {
        private readonly IDireccionServicio _direccionServicio;
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        private readonly IPaisServicio _paisServicio;

        public HelperDireccion(IDireccionServicio direccionServicio, ILocalidadServicio localidadServicio, IProvinciaServicio provinciaServicio, IPaisServicio paisServicio)
        {
            _direccionServicio = direccionServicio;
            _localidadServicio = localidadServicio;
            _provinciaServicio = provinciaServicio;
            _paisServicio = paisServicio;
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

            var localidad = (LocalidadDto)await _localidadServicio.Obtener(dto.LocalidadId);
            var provincia = (ProvinciaDto)await _provinciaServicio.Obtener(localidad.ProvinciaId);
            var pais = (PaisDto)await _paisServicio.Obtener(provincia.PaisId);

            var model = new DireccionViewModel()
            {
                Id = dto.Id,
                EstaEliminado = dto.EliminadoStr,
                Descripcion = dto.Descripcion,
                LocalidadId = dto.LocalidadId,
                Ubicacion = $"{localidad.Nombre}, {provincia.Nombre}, {pais.Nombre}"
            };

            return model;
        }
    }
}
