
namespace BeeWeb.DTOs.Responses
{
    public sealed record ValidationLoginResponse
    (
        bool isSuccess,
        DateTime FechaLogeo,
        List<string>? roles
    );
}
