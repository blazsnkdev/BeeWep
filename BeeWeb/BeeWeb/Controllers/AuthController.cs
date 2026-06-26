using BeeWeb.DTOs.Requests;
using BeeWeb.Models.ViewModels;
using BeeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace BeeWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authservice;
        public AuthController(IAuthService authservice)
        {
            _authservice = authservice;
        }
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authservice.AutenticacionUsuarioAsync(request);
            if (result.isSuccess && result.roles is not null)//si es logeo exitoso
            {
                var rolCliente = result.roles.Select(x => x == "Cliente").FirstOrDefault();
                var rolVendedor = result.roles.Select(x => x == "Vendedor").FirstOrDefault();
                if (rolCliente || rolVendedor)
                {
                    return RedirectToAction("Articulo", "Index");
                }
            }
            return RedirectToAction("Auth", "AccessDenied");
        }
    }
}
