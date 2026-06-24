using BeeWeb.Data.Context;
using BeeWeb.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BeeWeb.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(AppDbContext appDbContext, DbSet<T> dbSet)
        {
            _appDbContext = appDbContext;
            _dbSet = dbSet;
        }

        public async Task AddAsync(T entity)
        {
            await _appDbContext.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _appDbContext.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsyn(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
