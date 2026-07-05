using System.Security.Claims;

namespace BeeWeb.Utils
{
    public static class ClaimsExtensions
    {
        public static Guid GetUsuarioIdSesion(this ClaimsPrincipal user)
        {
            var claim = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(claim, out Guid usuarioId))
            {
                throw new UnauthorizedAccessException("Usuario no encotrado");
            }
            return usuarioId;
        }
    }
}
