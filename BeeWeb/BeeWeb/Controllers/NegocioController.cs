using BeeWeb.Models.ViewModels;
using BeeWeb.Services.Interfaces;
using BeeWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeeWeb.Controllers
{
    public class NegocioController : Controller
    {
        private readonly INegocioService _negocioService;

        public NegocioController(INegocioService negocioService)
        {
            _negocioService = negocioService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Perfil() 
        {
            Guid usuarioId = ClaimsExtensions.GetUsuarioIdSesion(User);
            var model = await _negocioService.DetallePerfilAsync(usuarioId);
            if(model is null)
            {
                return NotFound();
            }
            var viewModel = new PerfilViewModel()
            {
                NombreNegocio = model.Nombre,
                Direccion = model.Direccion,
                TipoMoneda = model.TipoMoneda,
                Rubro = model.Rubro,
                Descripcion = model.Descripcion,
                CodigoUsuario = model.Codigo,
                NombreUsuario = model.NombreUsuario
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Perfil(PerfilViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            return View();
        }
    }
}
