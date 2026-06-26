namespace BeeWeb.DTOs.Requests
{
    public sealed record LoginRequest
    (
        string nombreUsuarioInput,
        string PasswordUsuarioInput,
        List<string> roles
    );
}
