using BCrypt.Net;
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
            
            var usuario = await _uow.UsuarioRepository.ObtenerUsuarioPorCodigoAsync(request.codigoUsuarioInput);
            if (usuario is not null)
            {
                if (BCrypt.Net.BCrypt.Verify(request.PasswordUsuarioInput, usuario.PasswordHashed))
                {
                    var roles = await _uow.UsuarioRepository.ObtenerRolesPorUsuarioIdAsync(usuario.UsurioId);
                    return new ValidationLoginResponse(true, DateTime.Now, roles);
                }
            }
            return new ValidationLoginResponse(false,DateTime.Now,null);
        }
    }
}
