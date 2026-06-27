namespace BeeWeb.DTOs.Requests
{
    public sealed record RegistrarNegocioRequest
    (
        string nombre,
        string descripcion,
        string rubro,
        string tipoMoneda,
        string codigoUsuario,
        string direccion
    );
}
