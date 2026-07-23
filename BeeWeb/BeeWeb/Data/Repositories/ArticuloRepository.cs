using BeeWeb.Data.Context;
using BeeWeb.Data.Interfaces;
using BeeWeb.Models;

namespace BeeWeb.Data.Repositories
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly AppDbContext _appDbContext;
        public ArticuloRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
