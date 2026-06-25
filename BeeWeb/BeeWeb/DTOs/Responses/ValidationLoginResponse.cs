
namespace BeeWeb.DTOs.Responses
{
    public sealed record ValidationLoginResponse
    (
        List<string> roles,
        bool isSuccess,
        DateTime FechaLogin
    );
}
