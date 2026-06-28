using BeeWeb.Data.Context;
using BeeWeb.Data.Interfaces;
using BeeWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeWeb.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioRepository(AppDbContext appDbContext) : base (appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<string>> ObtenerRolesPorUsuarioIdAsync(Guid usuarioId)
        {
            var list = new List<string>();
            var usuario = await _appDbContext.TblUsuario
                .Where(x => x.UsurioId == usuarioId)
                .Include(x=>x.Roles)
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

        public async Task<Usuario?> ObtenerUsuarioPorCodigoAsync(string codigo)
        {
            return await _appDbContext.TblUsuario.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
        }
    }
}
