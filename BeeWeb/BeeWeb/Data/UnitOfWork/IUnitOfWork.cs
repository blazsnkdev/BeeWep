using BeeWeb.Data.Interfaces;

namespace BeeWeb.Data.UnitOfWork
{
    public interface IUnitOfWork 
    {
        public IUsuarioRepository UsuarioRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
