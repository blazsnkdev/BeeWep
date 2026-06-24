namespace BeeWeb.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsyn(Guid id);
        Task AddAsync(T entity);
        void Delete(T entity);
    }
}
