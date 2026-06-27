using BeeWeb.Data.Interfaces;

namespace BeeWeb.Data.UnitOfWork
{
    public interface IUnitOfWork 
    {
        public IUsuarioRepository UsuarioRepository { get; }
        public INegocioRepository NegocioRepository { get;}
        Task<int> SaveChangesAsync();
    }
}
