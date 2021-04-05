using System.Collections.Generic;
using System.Threading.Tasks;
using EM.IServicio.Localidad;
using EM.IServicio.Localidad.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EM.Presentacion.MVC.Helpers.Localidad
{
    public class HelperLocalidad : IHelperLocalidad
    {
        private readonly ILocalidadServicio _localidadServicio;

        public HelperLocalidad(ILocalidadServicio localidadServicio)
        {
            _localidadServicio = localidadServicio;
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerLocalidadesPorProvincia(long id)
        {
            var localidades = (IEnumerable<LocalidadDto>)await _localidadServicio.ObtenerPorProvincia(id);

            return new SelectList(localidades, "Id", "Nombre");
        }
    }
}
