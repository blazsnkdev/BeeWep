using BeeWeb.Data.Interfaces;

namespace BeeWeb.Data.UnitOfWork
{
    public interface IUnitOfWork 
    {
        public IUsuarioRepository UsuarioRepository { get; }
        public INegocioRepository NegocioRepository { get;}
        public IArticuloRepository ArticuloRepository { get;}
        Task<int> SaveChangesAsync();
    }
}
