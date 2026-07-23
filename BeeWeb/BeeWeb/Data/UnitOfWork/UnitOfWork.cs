using BeeWeb.Data.Context;
using BeeWeb.Data.Interfaces;

namespace BeeWeb.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public INegocioRepository NegocioRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }
        public IArticuloRepository ArticuloRepository { get; }

        private readonly AppDbContext _appDbContext;

        public UnitOfWork(
            IUsuarioRepository usuarioRepository,
            INegocioRepository negocioRepository,
            IArticuloRepository articuloRepository,
            AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            UsuarioRepository = usuarioRepository;
            NegocioRepository = negocioRepository;
            ArticuloRepository = articuloRepository;    
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}