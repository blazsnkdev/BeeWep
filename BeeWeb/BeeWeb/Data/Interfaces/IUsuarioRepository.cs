using BeeWeb.Models;

namespace BeeWeb.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> ValidarUSuarioAsync(string nombre, string clave);
        Task<List<string>> ObtenerRolesPorUsuarioIdAsync(Guid usuarioId);
        Task<Guid> ObtenerIdPorCodigoAsync(string codigousuario);
    }
}
