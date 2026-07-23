using BeeWeb.DTOs.Requests;
using BeeWeb.DTOs.Responses;

namespace BeeWeb.Services.Interfaces
{
    public interface IArticuloService
    {
        Task<CrearArticuloResponse> AgregarAsync(CrearArticuloRequest request);
    }
}
