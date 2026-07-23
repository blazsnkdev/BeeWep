namespace BeeWeb.DTOs.Requests
{
    public sealed record CrearArticuloRequest
    (
        Guid CategoriaId,
        Guid MarcaId,
        string NumeroParte,
        string Nombre,
        string Descripcion,
        bool PermiteSerie,
        string UnidadMedida
    );
}
