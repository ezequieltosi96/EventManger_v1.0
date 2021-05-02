using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EM.Dominio.Identity;
using EM.IServicio.Cliente;
using EM.IServicio.Cliente.Dto;
using EM.IServicio.Entrada;
using EM.IServicio.Entrada.Dto;
using EM.IServicio.Evento.Dto;
using EM.IServicio.FormaPagoTarjeta;
using EM.IServicio.FormaPagoTarjeta.Dto;
using EM.Presentacion.MVC.Helpers.Cliente;
using EM.Presentacion.MVC.Helpers.Entrada;
using EM.Presentacion.MVC.Helpers.Evento;
using EM.Presentacion.MVC.Helpers.FormaPago.Tarjeta;
using EM.Presentacion.MVC.Models.Cliente;
using EM.Presentacion.MVC.Models.Pago;
using Microsoft.AspNetCore.Identity;

namespace EM.Presentacion.MVC.Controllers
{
    public class PagoController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHelperCliente _helperCliente;
        private readonly IHelperEntrada _helperEntrada;
        private readonly IHelperEvento _helperEvento;
        private readonly IHelperFormaPagoTarjeta _helperFormaPagoTarjeta;
        private readonly IClienteServicio _clienteServicio;
        private readonly IFormaPagoTarjetaServicio _formaPagoTarjetaServicio;
        private readonly IEntradaServicio _entradaServicio;

        public PagoController(UserManager<AppUser> userManager, IHelperCliente helperCliente, IHelperEntrada helperEntrada, IHelperEvento helperEvento, IHelperFormaPagoTarjeta helperFormaPagoTarjeta, IClienteServicio clienteServicio, IFormaPagoTarjetaServicio formaPagoTarjetaServicio, IEntradaServicio entradaServicio)
        {
            _userManager = userManager;
            _helperCliente = helperCliente;
            _helperEntrada = helperEntrada;
            _helperEvento = helperEvento;
            _helperFormaPagoTarjeta = helperFormaPagoTarjeta;
            _clienteServicio = clienteServicio;
            _formaPagoTarjetaServicio = formaPagoTarjetaServicio;
            _entradaServicio = entradaServicio;
        }

        public IActionResult LoginOrContinue(long eventoId)
        {
            ViewBag.EventoId = eventoId;
            return View();
        }

        public async Task<IActionResult> SeleccionarEntradas(long eventoId)
        {
            ClienteViewModel cliente = new ClienteViewModel();
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Cliente"))
                {
                    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                    cliente = await _helperCliente.ObtenerClienteViewModelPorEmail(user.Email);
                }
            }

            var model = new PagoViewModel()
            {
                Cliente = cliente,
                EntradasGenericas = await _helperEntrada.PoblarComboGeneric(eventoId)
            };

            ViewBag.DatosInvalidos = false;
            ViewBag.EntradaInsuficiente = false;
            ViewBag.ClienteExistente = false;
            ViewBag.EventoId = eventoId;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SeleccionarEntradas(PagoViewModel vm, long eventoId)
        {
            try
            {
                ViewBag.DatosInvalidos = false;
                ViewBag.EntradaInsuficiente = false;
                ViewBag.ClienteExistente = false;
                ViewBag.EventoId = eventoId;

                if (!ModelState.IsValid)
                {
                    ViewBag.DatosInvalidos = true;
                    throw new Exception("Error de validacion no controlado.");
                }

                var evento = await _helperEvento.Obtener(eventoId);
                if (evento.CupoDisponible < vm.Cantidad)
                {
                    ViewBag.EntradaInsuficiente = true;
                    throw new Exception("Cantidad de entradas insuficiente.");
                }

                long clienteId = vm.Cliente.Id;
                var clienteVm = vm.Cliente;

                if (!User.Identity.IsAuthenticated)
                {
                    var existe = await _helperCliente.ExisteCliente(vm.Cliente.Dni, vm.Cliente.Email);
                    if (existe)
                    {
                        ViewBag.ClienteExistente = true;
                        throw new Exception("Ya existe un cliente con los datos especificados.");
                    }

                    var clienteDto = new ClienteDto()
                    {
                        Apellido = vm.Cliente.Apellido,
                        Nombre = vm.Cliente.Nombre,
                        Dni = vm.Cliente.Dni,
                        Email = vm.Cliente.Email
                    };
                    clienteId = await _clienteServicio.InsertarDevuelveId(clienteDto);
                    clienteVm = await _helperCliente.Obtener(clienteId);
                }

                await _helperEvento.ActualizarCupoDisponible(evento.Id, vm.Cantidad);


                // guardo la forma de pago
                var formaPagoDto = new FormaPagoTarjetaDto()
                {
                    Nombre = vm.FormaPago.Nombre,
                    NumeroTarjeta = vm.FormaPago.NumeroTarjeta,
                    AnioExp = vm.FormaPago.AnioExp,
                    MesExp = vm.FormaPago.MesExp,
                    CodigoSeguridad = vm.FormaPago.CodigoSeguridad,
                    CodigoPostal = vm.FormaPago.CodigoPostal,
                    DireccionFacturacion = vm.FormaPago.DireccionFacturacion
                };
                var formaPagoId = await _formaPagoTarjetaServicio.InsertarDevuelveId(formaPagoDto);
                var formaPagoVm = await _helperFormaPagoTarjeta.Obtener(formaPagoId);

                // guardo las entradas para el cliente (for int i=0; 1 < cantidad; i++)
                var entradaVm = await _helperEntrada.ObtenerEntrada(vm.EntradaId);
                for (int i = 0; i < vm.Cantidad; i++)
                {
                    var entrada = new EntradaDto()
                    {
                        ClienteId = clienteId,
                        EventoId = entradaVm.EventoId,
                        Precio = entradaVm.Precio,
                        TipoEntradaId = entradaVm.TipoEntradaId
                    };
                    await _entradaServicio.Insertar(entrada);
                }

                return RedirectToAction("AltaFactura", "FacturaPDF", new { clienteId = clienteVm.Id, formaPagoId = formaPagoVm.Id, entradaId = entradaVm.Id, cantidad = vm.Cantidad });
            }
            catch (Exception)
            {
                return View(vm);
            }
        }
    }
}
