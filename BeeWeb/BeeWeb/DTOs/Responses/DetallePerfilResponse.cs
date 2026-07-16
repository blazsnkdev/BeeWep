namespace BeeWeb.DTOs.Responses
{
    public sealed record DetallePerfilResponse
    (
        string Nombre,
        string Direccion,
        string Rubro,
        string Descripcion,
        string TipoMoneda,
        string NombreUsuario,
        string Codigo
    );
}
