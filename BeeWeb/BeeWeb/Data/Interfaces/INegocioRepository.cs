using BeeWeb.Models;

namespace BeeWeb.Data.Interfaces
{
    public interface INegocioRepository : IRepository<Negocio>
    {
        Task<Guid> RegistrarAsync(Negocio negocio);
        Task<Negocio?> DetalePorUsuarioIdAsync(Guid usuarioId);
    }
}
