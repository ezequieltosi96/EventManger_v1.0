using EM.IServicio.Factura;
using EM.IServicio.Factura.Dto;
using EM.Presentacion.MVC.Helpers.Cliente;
using EM.Presentacion.MVC.Helpers.Empresa;
using EM.Presentacion.MVC.Helpers.FormaPago;
using EM.Presentacion.MVC.Models.Factura;
using EM.Presentacion.MVC.Models.FacturaDetalle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EM.Presentacion.MVC.Controllers
{
    public class FacturaPDFController : Controller
    {
        private readonly IFacturaServicio _facturaServicio;
        private readonly IHelperEmpresa _helperEmpresa;
        private readonly IHelperCliente _helperCliente;
        private readonly IHelperFormaPago _helperFormaPago;
        public FacturaPDFController(IFacturaServicio facturaServicio, IHelperEmpresa helperEmpresa, IHelperCliente helperCliente, IHelperFormaPago helperFormaPago)
        {
            _facturaServicio = facturaServicio;
            _helperEmpresa = helperEmpresa;
            _helperCliente = helperCliente;
            _helperFormaPago = helperFormaPago;
        }

        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Index(string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";
            IEnumerable<FacturaDto> dtos;
            dtos = (IEnumerable<FacturaDto>)await _facturaServicio.Obtener(cadenaBuscar, mostrarTodos);

            var models = dtos.Select(d => new FacturaViewModel()
            {
                Id = d.Id,                
                EstaEliminado = d.EliminadoStr,
                Fecha = d.Fecha,
                TipoFactura = d.TipoFactura,
                Total = d.Total
            }).ToList();

            ViewBag.MostrarTodos = mostrarTodos;
            ViewBag.CadenaBuscar = cadenaBuscar;

            return View(models);
        }
        [Authorize(Roles = "Admin, Empresa")]
        public async Task<IActionResult> Details(long id)
        {
            try
            {
                var dto = (FacturaDto)await _facturaServicio.Obtener(id);
                
                var model = new FacturaViewModel()
                {
                    Id = dto.Id,
                    ClienteId = dto.ClienteId,
                    EmpresaId = dto.EmpresaId,
                    FormaPagoId = dto.FormaPagoId,
                    EstaEliminado = dto.EliminadoStr,
                    Fecha = dto.Fecha,
                    Total = dto.Total,
                    TipoFactura = dto.TipoFactura,
                    FacturaDetalles = dto.FacturaDetalles.Select(d => new FacturaDetalleViewModel()
                    {
                        FacturaId = d.FacturaId,
                        EntradaId = d.EntradaId,
                        Cantidad = d.Cantidad,
                        SubTotal = d.SubTotal
                    }),
                    Cliente = _helperCliente.ObtenerNombreCliente(dto.ClienteId).Result,
                    Empresa = _helperEmpresa.ObtenerEmpresa(dto.EmpresaId).Result,
                    FormaPago = _helperFormaPago.ObtenerFormaPago(dto.FormaPagoId).Result,
                };
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<ActionResult> Imprimir(long id)
        {
            try
            {
                var dto = (FacturaDto)await _facturaServicio.Obtener(id);

                var model = new FacturaViewModel()
                {
                    Id = dto.Id,
                    ClienteId = dto.ClienteId,
                    EmpresaId = dto.EmpresaId,
                    FormaPagoId = dto.FormaPagoId,
                    EstaEliminado = dto.EliminadoStr,
                    Fecha = dto.Fecha,
                    Total = dto.Total,
                    TipoFactura = dto.TipoFactura,
                    FacturaDetalles = dto.FacturaDetalles.Select(d => new FacturaDetalleViewModel()
                    {
                        FacturaId = d.FacturaId,
                        EntradaId = d.EntradaId,
                        Cantidad = d.Cantidad,
                        SubTotal = d.SubTotal
                    }),
                    Cliente = _helperCliente.ObtenerNombreCliente(dto.ClienteId).Result,
                    Empresa = _helperEmpresa.ObtenerEmpresa(dto.EmpresaId).Result,
                    FormaPago = _helperFormaPago.ObtenerFormaPago(dto.FormaPagoId).Result,
                };
                return new ViewAsPdf("PDF", model);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }          
        }

        public IActionResult PDF(FacturaViewModel model)
        {
            return View(model);
        }
    }
}
