using EM.Presentacion.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EM.Presentacion.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.CadenaBuscar = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string cadenaBuscar)
        {
            ViewBag.CadenaBuscar = cadenaBuscar;
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
