using EM.IServicio.Pais;
using EM.IServicio.Pais.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Helpers.Pais
{
    public class HelperPais : IHelperPais
    {
        private readonly IPaisServicio _paisServicio;

        public HelperPais(IPaisServicio paisServicio)
        {
            _paisServicio = paisServicio;
        }

        public async Task<IEnumerable<SelectListItem>> PoblarSelect()
        {
            var paises = (IEnumerable<PaisDto>)await _paisServicio.Obtener(String.Empty, false);

            return new SelectList(paises, "Id", "Nombre");
        }

        public async Task<string> ObtenerNombrePais(long id)
        {
            return ((PaisDto)await _paisServicio.Obtener(id)).Nombre;
        }
    }
}
