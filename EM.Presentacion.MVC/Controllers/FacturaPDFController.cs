using EM.IServicio.Factura;
using EM.IServicio.Factura.Dto;
using EM.IServicio.FacturaDetalle;
using EM.IServicio.FacturaDetalle.Dto;
using EM.Presentacion.MVC.Helpers.Cliente;
using EM.Presentacion.MVC.Helpers.Empresa;
using EM.Presentacion.MVC.Helpers.Entrada;
using EM.Presentacion.MVC.Helpers.FormaPago;
using EM.Presentacion.MVC.Models.Entrada;
using EM.Presentacion.MVC.Models.Factura;
using EM.Presentacion.MVC.Models.FacturaDetalle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.Presentacion.MVC.Models.Cliente;
using EM.Presentacion.MVC.Models.FormaPagoTarjeta;

namespace EM.Presentacion.MVC.Controllers
{
    public class FacturaPDFController : Controller
    {
        private readonly IFacturaServicio _facturaServicio;
        private readonly IFacturaDetalleServicio _facturadetalleServicio;
        private readonly IHelperEmpresa _helperEmpresa;
        private readonly IHelperCliente _helperCliente;
        private readonly IHelperFormaPago _helperFormaPago;
        private readonly IHelperEntrada _helperEntrada;
        public FacturaPDFController(IFacturaServicio facturaServicio, IHelperEmpresa helperEmpresa, IHelperCliente helperCliente, IHelperFormaPago helperFormaPago, IHelperEntrada helperEntrada, IFacturaDetalleServicio facturaDetalleServicio)
        {
            _facturaServicio = facturaServicio;
            _helperEmpresa = helperEmpresa;
            _helperCliente = helperCliente;
            _helperFormaPago = helperFormaPago;
            _helperEntrada = helperEntrada;
            _facturadetalleServicio = facturaDetalleServicio;
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
        public async Task<IActionResult> IndexEmpresa(long? empresaId = null,string cadenaBuscar = "", bool mostrarTodos = false)
        {
            if (cadenaBuscar == null) cadenaBuscar = "";
            IEnumerable<FacturaDto> dtos;
            var empresa = await _helperEmpresa.ObtenerEmpresaActual(User.Identity.Name);
            empresaId = empresa.Id;
            dtos = (IEnumerable<FacturaDto>)await _facturaServicio.ObtenerPorEmpresa(empresaId.Value,cadenaBuscar, mostrarTodos);

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
                        SubTotal = d.SubTotal,
                        Entrada = _helperEntrada.ObtenerEntrada(d.EntradaId).Result
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
                        SubTotal = d.SubTotal,
                        Entrada = _helperEntrada.ObtenerEntrada(d.EntradaId).Result
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

        public async Task<ActionResult> Alta(long entradaId, long formaPagoId)
        {
            var entrada = await _helperEntrada.ObtenerEntrada(entradaId);
            var evento = entrada.Evento;

            var factura = new FacturaDto()
            {
                ClienteId = entrada.ClienteId.Value,
                EmpresaId = evento.EmpresaId,
                FormaPagoId = formaPagoId,
                Fecha = DateTime.Today,
                TipoFactura = Dominio.Enum.TipoFactura.B,
                Total = entrada.Precio
            };

            long facturaId = await _facturaServicio.InsertarDevuelveId(factura);

            var facturaDetalle = new FacturaDetalleDto()
            {
                Cantidad = 1,
                EntradaId = entradaId,
                FacturaId = facturaId,
                SubTotal = entrada.Precio
            };

            await _facturadetalleServicio.Insertar(facturaDetalle);

            return RedirectToAction("Imprimir", "FacturaPDF", new { @id = facturaId });
        }

        public async Task<IActionResult> AltaFactura(long clienteId, long formaPagoId, long entradaId, int cantidad)
        {
            var entrada = await _helperEntrada.ObtenerEntrada(entradaId);
            var evento = entrada.Evento;
            var factura = new FacturaDto()
            {
                ClienteId = clienteId,
                EmpresaId = evento.EmpresaId,
                FormaPagoId = formaPagoId,
                Fecha = DateTime.Now,
                TipoFactura = Dominio.Enum.TipoFactura.B,
                Total = cantidad * entrada.Precio
            };
            long facturaId = await _facturaServicio.InsertarDevuelveId(factura);

            var facturaDetalle = new FacturaDetalleDto()
            {
                Cantidad = cantidad,
                EntradaId = entrada.Id,
                FacturaId = facturaId,
                SubTotal = cantidad * entrada.Precio
            };
            await _facturadetalleServicio.Insertar(facturaDetalle);

            return RedirectToAction("Imprimir", "FacturaPDF", new { id = facturaId });
        }
    }
}
