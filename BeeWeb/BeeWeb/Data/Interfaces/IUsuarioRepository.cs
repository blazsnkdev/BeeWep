using BeeWeb.Models;

namespace BeeWeb.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> ObtenerUsuarioPorCodigoAsync(string codigo);
        Task<List<string>> ObtenerRolesPorUsuarioIdAsync(Guid usuarioId);
    }
}
