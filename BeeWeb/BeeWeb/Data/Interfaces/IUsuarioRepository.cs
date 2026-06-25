using BeeWeb.Models;

namespace BeeWeb.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> ValidarUSuarioAsync(string nombre, string clave);
    }
}
