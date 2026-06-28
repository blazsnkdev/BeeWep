using BeeWeb.DTOs.Requests;
using BeeWeb.Models.ViewModels;
using BeeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeeWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authservice;
        private readonly INegocioService _negocioService;
        public AuthController(
            IAuthService authservice,
            INegocioService negocioService)
        {
            _authservice = authservice;
            _negocioService = negocioService;
        }
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)//NOTE: OJITO AQUÍ FLACO PODES ARREGLARLO
        {
            var result = await _authservice.AutenticacionUsuarioAsync(new LoginRequest(viewModel.Codigo,viewModel.Password));
            if (result.isSuccess && result.roles is not null)
            {
                var rolCliente = result.roles.Select(x => x == "Cliente").FirstOrDefault();
                var rolVendedor = result.roles.Select(x => x == "Vendedor").FirstOrDefault();
                if (rolCliente)
                {
                    return RedirectToAction("Articulo", "Index");
                }
                if (rolCliente || rolVendedor)
                {
                    return RedirectToAction("Articulo", "Index");
                }
            }
            return RedirectToAction("Auth", "AccessDenied");
        }
        public IActionResult RegistrarTienda()
        {
            return View(new RegistrarTiendaViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarTienda(RegistrarTiendaViewModel viewModel)
        {
            var result = await _negocioService.RegistrarAsync(new RegistrarNegocioRequest(
                viewModel.Nombre,
                viewModel.Descripcion,
                viewModel.Rubro,
                viewModel.TipoMoneda,
                viewModel.CodigoUsuario,
                viewModel.Direccion));
            if(result == Guid.Empty)//NOTE: ojito aqui flaco
            {
                return View(viewModel);
            }
            return RedirectToAction(nameof(Login));
        }
    }
}
