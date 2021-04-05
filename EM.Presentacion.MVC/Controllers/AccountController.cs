using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EM.Dominio.Identity;
using EM.Presentacion.MVC.Helpers.Cliente;
using EM.Presentacion.MVC.Helpers.Direccion;
using EM.Presentacion.MVC.Helpers.Empresa;
using EM.Presentacion.MVC.Helpers.Pais;
using EM.Presentacion.MVC.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EM.Presentacion.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IHelperCliente _helperCliente;
        private readonly IHelperEmpresa _helperEmpresa;
        private readonly IHelperDireccion _helperDireccion;
        private readonly IHelperPais _helperPais;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IHelperCliente helperCliente, IHelperEmpresa helperEmpresa, IHelperDireccion helperDireccion, IHelperPais helperPais)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _helperCliente = helperCliente;
            _helperEmpresa = helperEmpresa;
            _helperDireccion = helperDireccion;
            _helperPais = helperPais;
        }

        public IActionResult Register()
        {
            ViewBag.ClienteDuplicado = false;
            ViewBag.EmailRequerido = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UsuarioClienteViewModel vm)
        {
            try
            {
                ViewBag.ClienteDuplicado = false;
                ViewBag.EmailRequerido = false;
                if (!ModelState.IsValid)
                {
                    if (vm.Cliente.Email == null) ViewBag.EmailRequerido = true;
                    throw new Exception("Error de validacion no controlado.");
                }

                // verificar que no exista un cliente con el mismo dni
                var existeCliente = await _helperCliente.ExisteCliente(vm.Cliente.Dni);
                if (existeCliente)
                {
                    ViewBag.ClienteDuplicado = true;
                    throw new Exception("Cliente existente.");
                }

                // validar el usuario
                var user = new AppUser()
                {
                    UserName = vm.Cliente.Email,
                    Email = vm.Cliente.Email,
                    NombreMostrar = $"{vm.Cliente.Nombre} {vm.Cliente.Apellido}",
                };

                var usuarioCreado = await _userManager.CreateAsync(user, vm.Password);
                if (!usuarioCreado.Succeeded)
                {
                    ViewBag.UsuarioDuplicado = usuarioCreado;
                    ViewBag.ClienteDuplicado = true;
                    throw new Exception("Error al crear usuario");
                }

                // verificar si existe el rol "Cliente" -> si no existe crearlo
                var existeRol = await _roleManager.FindByNameAsync("Cliente");
                if (existeRol == null)
                {
                    var rol = new AppRole()
                    {
                        Name = "Cliente"
                    };
                    await _roleManager.CreateAsync(rol);
                }

                // asignar rol "Cliente" al usuario
                await _userManager.AddToRoleAsync(user, "Cliente");

                // guardar el cliente si lo anterior es valido -> si no es valido eliminar el usuario y arrojar Exception()
                var clienteCreado = await _helperCliente.NuevoCliente(vm.Cliente);
                if (!clienteCreado)
                {
                    await _userManager.DeleteAsync(user);
                    throw new Exception("Error al crear cliente.");
                }

                // realizar login y redireccionar a index
                var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);
                if (!result.Succeeded)
                {
                    throw new Exception("Error al inicir sesion.");
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        public async Task<IActionResult> EmpresaRegister()
        {
            ViewBag.EmpresaDuplicada = false;
            ViewBag.EmailRequerido = false;
            var paises = await _helperPais.PoblarSelect();
            var vm = new UsuarioEmpresaViewModel()
            {
                Paises = paises,
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmpresaRegister(UsuarioEmpresaViewModel vm)
        {
            try
            {
                ViewBag.EmpresaDuplicada = false;
                ViewBag.EmailRequerido = false;
                if (!ModelState.IsValid)
                {
                    if (vm.Empresa.Email == null) ViewBag.EmailRequerido = true;
                    throw new Exception("Error de validacion no controlado.");
                }

                // verificar que no exista una empresa con el mismo cuil y razon social
                var existeEmpresa = await _helperEmpresa.ExisteEmpresa(vm.Empresa.Cuil, vm.Empresa.RazonSocial);
                if (existeEmpresa)
                {
                    ViewBag.EmpresaDuplicada = true;
                    throw new Exception("Empresa existente.");
                }

                // verificar que no exista una direccion con la misma descripcion y localidadId -> si existe no crearla y obtener el Id
                var direccionId = await _helperDireccion.ExisteDireccion(vm.Empresa.Direccion);
                if (!direccionId.HasValue)
                {
                    // creamos la direccion y optenemos el id
                    direccionId = await _helperDireccion.NuevaDireccion(vm.Empresa.Direccion);
                }

                vm.Empresa.DireccionId = direccionId.Value;

                // validar el usuario
                var user = new AppUser()
                {
                    UserName = vm.Empresa.Email,
                    Email = vm.Empresa.Email,
                    NombreMostrar = vm.Empresa.RazonSocial
                };

                var usuarioCreado = await _userManager.CreateAsync(user, vm.Password);
                if (!usuarioCreado.Succeeded)
                {
                    ViewBag.UsuarioCreado = usuarioCreado;
                    ViewBag.EmpresaDuplicada = true;
                    throw new Exception("Error al crear usuario.");
                }

                // verificar si existe el rol "Empresa" -> si no existe crearlo
                var existeRol = await _roleManager.FindByNameAsync("Empresa");
                if (existeRol == null)
                {
                    var rol = new AppRole()
                    {
                        Name = "Empresa"
                    };
                    await _roleManager.CreateAsync(rol);
                }

                // asignar el rol al usuario
                await _userManager.AddToRoleAsync(user, "Empresa");

                // guardar la empresa si lo anterior es valido -> si no es valido eliminar el usuario y arrojar new Exception()
                var empresaCreada = await _helperEmpresa.NuevaEmpresa(vm.Empresa);
                if (!empresaCreada)
                {
                    await _userManager.DeleteAsync(user);
                    throw new Exception("Error al crear la empresa.");
                }

                // realizar login y redireccionar a home
                var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);
                if (!result.Succeeded)
                {
                    throw new Exception("Error al inicir sesion.");
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Empresa, Cliente, Admin")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(UsuarioViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Error de validacion no controlado");

                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, false, false);

                if (!result.Succeeded)
                {
                    throw new Exception("Error al iniciar sesion.");
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View(vm);
            }
        }

        [Authorize(Roles = "Empresa, Cliente, Admin")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains("Empresa"))
            {
                return RedirectToAction("Profile", "Empresa", new { email = user.Email });
            }

            if (roles.Contains("Cliente"))
            {
                return RedirectToAction("Profile", "Cliente", new { email = user.Email });
            }

            return RedirectToAction(nameof(AdminProfile));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminProfile()
        {
            return View();
        }
    }
}
