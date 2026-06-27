using BeeWeb.Data.Context;
using BeeWeb.Data.Interfaces;

namespace BeeWeb.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IUsuarioRepository usuarioRepository,
            INegocioRepository negocioRepository,

            AppDbContext appDbContext
            )
        {
            UsuarioRepository = usuarioRepository;
            NegocioRepository = negocioRepository;
            _appDbContext = appDbContext;
        }
        public INegocioRepository NegocioRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        private readonly AppDbContext _appDbContext;
        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
