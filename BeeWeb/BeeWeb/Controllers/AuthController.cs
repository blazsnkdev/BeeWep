using BeeWeb.DTOs.Requests;
using BeeWeb.Models.ViewModels;
using BeeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            var validation = await _authservice.AutenticacionUsuarioAsync(request);
            if (!validation.isSuccess)
            {
                return RedirectToAction("","");
            }
            return RedirectToAction("", "");
        }
    }
}
