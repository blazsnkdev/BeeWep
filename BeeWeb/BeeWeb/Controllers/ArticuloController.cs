using BeeWeb.DTOs.Requests;
using BeeWeb.Models.ViewModels;
using BeeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BeeWeb.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly IArticuloService _articuloService;

        public ArticuloController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        public IActionResult Registrar()
        {
            return View(new RegistrarArticuloViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(RegistrarArticuloViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var response = await _articuloService.AgregarAsync(new CrearArticuloRequest(
                viewModel.CategoriaId,
                viewModel.MarcaId,
                viewModel.NumeroParte,
                viewModel.Nombre,
                viewModel.Descripcion,
                viewModel.PermiteSerie,
                viewModel.UnidadMedida));
            if (response.Reset)
            {

            }
            return View();
        }
    }
}
