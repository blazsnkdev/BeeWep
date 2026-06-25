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
        public async Task<bool> ValidarUSuarioAsync(string nombre, string clave)
        {
            return await _appDbContext
                .TblUsuario
                .AnyAsync(x => x.Nombre == nombre && x.PasswordHashed == clave);
        }
    }
}
