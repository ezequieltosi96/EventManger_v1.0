using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Controllers
{
    public class PagoController : Controller
    {
        public IActionResult LoginOrContinue(long eventoId)
        {
            ViewBag.EventoId = eventoId;
            return View();
        }

        public IActionResult SeleccionarEntradas(long eventoId)
        {
            // buscar entradas con eventoId y con clienteId = null

            // poblar el combo

            return View();
        }
    }
}
