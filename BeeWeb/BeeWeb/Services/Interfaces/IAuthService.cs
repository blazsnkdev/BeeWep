using BeeWeb.DTOs.Requests;
using BeeWeb.DTOs.Responses;

namespace BeeWeb.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ValidationLoginResponse> AutenticacionUsuarioAsync(LoginRequest request);
    }
}
