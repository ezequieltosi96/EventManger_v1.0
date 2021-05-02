using EM.IServicio.Provincia;
using EM.IServicio.Provincia.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Provincia
{
    public class HelperProvincia : IHelperProvincia
    {
        private readonly IProvinciaServicio _provinciaServicio;

        public HelperProvincia(IProvinciaServicio provinciaServicio)
        {
            _provinciaServicio = provinciaServicio;
        }

        public async Task<IEnumerable<SelectListItem>> PoblarSelect()
        {
            var provincias = (IEnumerable<ProvinciaDto>)await _provinciaServicio.Obtener(String.Empty, false);

            return new SelectList(provincias, "Id", "Nombre");
        }

        public async Task<IEnumerable<SelectListItem>> ObtenerProvinciasPorPais(long id)
        {
            var provincias = (IEnumerable<ProvinciaDto>)await _provinciaServicio.ObtenerPorPais(id);

            return new SelectList(provincias, "Id", "Nombre");
        }

        public async Task<string> ObtenerNombreProvincia(long id)
        {
            return ((ProvinciaDto)await _provinciaServicio.Obtener(id)).Nombre;
        }

        public async Task<long> ObtenerPaisId(long id)
        {
            return ((ProvinciaDto)await _provinciaServicio.Obtener(id)).PaisId;
        }
    }
}
