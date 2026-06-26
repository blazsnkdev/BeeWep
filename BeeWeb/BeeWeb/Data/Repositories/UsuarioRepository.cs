using BeeWeb.Data.Context;
using BeeWeb.Data.Interfaces;
using BeeWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeWeb.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;
        public UsuarioRepository(AppDbContext appDbContext, DbSet<Usuario> dbSet) : base(appDbContext, dbSet)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> ObtenerRolesPorUsuarioIdAsync(Guid usuarioId)
        {
            var list = new List<string>();
            var usuario = await _appDbContext.TblUsuario
                .Where(x => x.UsurioId == usuarioId)
                .FirstOrDefaultAsync();

            if(usuario is not null)
            {
                foreach (var rol in usuario.Roles)
                {
                    list.Add(rol.Nombre);
                }
            }
            return list;
        }

        public async Task<Usuario?> ValidarUSuarioAsync(string nombre, string clave)
        {
            return await _appDbContext
                .TblUsuario
                .FirstOrDefaultAsync(x => x.Nombre == nombre && x.PasswordHashed == clave);
        }
    }
}
