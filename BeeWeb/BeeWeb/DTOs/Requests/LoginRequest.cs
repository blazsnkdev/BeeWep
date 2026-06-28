namespace BeeWeb.DTOs.Requests
{
    public sealed record LoginRequest
    (
        string codigoUsuarioInput,
        string PasswordUsuarioInput
    );
}
