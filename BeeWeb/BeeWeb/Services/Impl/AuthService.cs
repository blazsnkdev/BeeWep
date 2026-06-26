using BeeWeb.Data.UnitOfWork;
using BeeWeb.DTOs.Requests;
using BeeWeb.DTOs.Responses;
using BeeWeb.Services.Interfaces;

namespace BeeWeb.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _uow;

        public AuthService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ValidationLoginResponse> AutenticacionUsuarioAsync(LoginRequest request)
        {
            var usuario = await _uow.UsuarioRepository.ValidarUSuarioAsync(request.nombreUsuarioInput, request.PasswordUsuarioInput);
            if (usuario is not null)
            {
                var roles = await _uow.UsuarioRepository.ObtenerRolesPorUsuarioIdAsync(usuario.UsurioId);
                var response = new ValidationLoginResponse(true,DateTime.Now,roles);
            }
            return new ValidationLoginResponse(false,DateTime.Now,null);
        }
    }
}
