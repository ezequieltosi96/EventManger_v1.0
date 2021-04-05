using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.IServicio.Empresa;
using EM.IServicio.Empresa.Dto;
using EM.Presentacion.MVC.Helpers.Direccion;
using EM.Presentacion.MVC.Models.Empresa;

namespace EM.Presentacion.MVC.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaServicio _empresaServicio;
        private readonly IHelperDireccion _helperDireccion;

        public EmpresaController(IEmpresaServicio empresaServicio, IHelperDireccion helperDireccion)
        {
            _empresaServicio = empresaServicio;
            _helperDireccion = helperDireccion;
        }

        public async Task<IActionResult> Profile(string email)
        {
            var dto = (EmpresaDto)await _empresaServicio.ObtenerPorEmail(email);

            var direccionVm = await _helperDireccion.ObtenerDireccion(dto.DireccionId);

            var model = new EmpresaViewModel()
            {
                RazonSocial = dto.RazonSocial,
                NombreFantasia = dto.NombreFantasia,
                Cuil = dto.Cuil,
                DireccionStr = direccionVm.Descripcion,
                Direccion = direccionVm,
                Email = dto.Email,
                EstaEliminado = dto.EliminadoStr,
                Id = dto.Id
            };

            return View(model);
        }
    }
}
