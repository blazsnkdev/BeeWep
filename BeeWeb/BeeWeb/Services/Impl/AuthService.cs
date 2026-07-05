using BeeWeb.Data.UnitOfWork;
using BeeWeb.DTOs.Requests;
using BeeWeb.DTOs.Responses;
using BeeWeb.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _uow;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(
        IUnitOfWork uow,
        IHttpContextAccessor httpContextAccessor)
    {
        _uow = uow;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ValidationLoginResponse> AutenticacionUsuarioAsync(LoginRequest request)
    {
        var usuario = await _uow.UsuarioRepository.ObtenerUsuarioPorCodigoAsync(request.codigoUsuarioInput);

        if (usuario is not null)
        {
            if (BCrypt.Net.BCrypt.Verify(request.PasswordUsuarioInput, usuario.PasswordHashed))
            {
                var roles = await _uow.UsuarioRepository.ObtenerRolesPorUsuarioIdAsync(usuario.UsurioId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.UsurioId.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Codigo)
                };

                foreach (var rol in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var identity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await _httpContextAccessor.HttpContext!.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return new ValidationLoginResponse(true, DateTime.Now, roles);
            }
        }

        return new ValidationLoginResponse(false, DateTime.Now, null);
    }
}