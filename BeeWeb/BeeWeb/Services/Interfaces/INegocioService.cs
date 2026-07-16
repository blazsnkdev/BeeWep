using BeeWeb.DTOs.Requests;
using BeeWeb.DTOs.Responses;

namespace BeeWeb.Services.Interfaces
{
    public interface INegocioService
    {
        Task<Guid> RegistrarAsync(RegistrarNegocioRequest request);
        Task<DetallePerfilResponse?> DetallePerfilAsync(Guid usuarioId);
    }
}
