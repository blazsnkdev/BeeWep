using BeeWeb.Data.UnitOfWork;
using BeeWeb.DTOs.Requests;
using BeeWeb.DTOs.Responses;
using BeeWeb.Models;
using BeeWeb.Services.Interfaces;

namespace BeeWeb.Services.Impl
{
    public class ArticuloService : IArticuloService
    {
        private readonly IUnitOfWork _Uow;

        public ArticuloService(IUnitOfWork uow)
        {
            _Uow = uow;
        }

        public async Task<CrearArticuloResponse> AgregarAsync(CrearArticuloRequest request)
        {
            try
            {
                await _Uow.ArticuloRepository.AddAsync(new Articulo()
                {
                    ArticuloId = Guid.CreateVersion7(),
                    Codigo = _Uow.ArticuloRepository.GetAllAsync().Result.Count() + 1,
                    NumeroParte = request.NumeroParte,
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    CategoriaId = request.CategoriaId,
                    MarcaId = request.MarcaId,
                    PermiteSeries = request.PermiteSerie,
                    UnidadMedida = request.UnidadMedida

                });
                await _Uow.SaveChangesAsync();
                return new CrearArticuloResponse(null, false, "Registrado Con Exito!");
            }
            catch (Exception ex)
            {
                return new CrearArticuloResponse(ex.Message,true,"Ocurrio un Error");
            }
        }
    }
}
