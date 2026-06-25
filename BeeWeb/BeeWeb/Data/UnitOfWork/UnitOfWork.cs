using BeeWeb.Data.Context;
using BeeWeb.Data.Interfaces;

namespace BeeWeb.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IUsuarioRepository usuarioRepository,
            AppDbContext appDbContext
            )
        {
            UsuarioRepository = usuarioRepository;
            _appDbContext = appDbContext;
        }
        public IUsuarioRepository UsuarioRepository { get; }
        private readonly AppDbContext _appDbContext;
        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
