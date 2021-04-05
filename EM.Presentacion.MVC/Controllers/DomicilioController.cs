using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Helpers.Localidad;

namespace EM.Presentacion.MVC.Controllers
{
    public class DomicilioController : Controller
    {
        private readonly IHelperLocalidad _helperLocalidad;

        public DomicilioController(IHelperLocalidad helperLocalidad)
        {
            _helperLocalidad = helperLocalidad;
        }

        public async Task<JsonResult> ObtenerLocalidadesPorProvincia(long provinciaId)
        {
            var localidades = await _helperLocalidad.ObtenerLocalidadesPorProvincia(provinciaId);

            return Json(localidades);
        }
    }
}
