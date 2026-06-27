using BeeWeb.DTOs.Requests;

namespace BeeWeb.Services.Interfaces
{
    public interface INegocioService
    {
        Task<Guid> RegistrarAsync(RegistrarNegocioRequest request);
    }
}
