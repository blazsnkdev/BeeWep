namespace BeeWeb.DTOs.Responses
{
    public sealed record CrearArticuloResponse
    (
        string? TextError,
        bool Reset,
        string? Message
    );
}
