using EM.IServicio.Localidad;
using EM.IServicio.Localidad.Dto;
using EM.IServicio.Provincia;
using EM.IServicio.Provincia.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Localidad
{
    public class HelperLocalidad : IHelperLocalidad
    {
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IProvinciaServicio _provinciaServicio;
        public HelperLocalidad(ILocalidadServicio localidadServicio, IProvinciaServicio provinciaServicio)
        {
            _localidadServicio = localidadServicio;
            _provinciaServicio = provinciaServicio;
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerLocalidadesPorProvincia(long id)
        {
            var localidades = (IEnumerable<LocalidadDto>)await _localidadServicio.ObtenerPorProvincia(id);

            return new SelectList(localidades, "Id", "Nombre");
        }

        public async Task<long> ObtenerPaisIdPorLocalidad(long localidadId)
        {
            var localidad = (LocalidadDto)await _localidadServicio.Obtener(localidadId);

            var provincia = (ProvinciaDto)await _provinciaServicio.Obtener(localidad.ProvinciaId);

            return provincia.PaisId;
        }

        public async Task<long> ObtenerProvinciaIdPorLocalidad(long localidadId)
        {
            var localidad = (LocalidadDto)await _localidadServicio.Obtener(localidadId);

            return localidad.ProvinciaId;
        }
    }
}
