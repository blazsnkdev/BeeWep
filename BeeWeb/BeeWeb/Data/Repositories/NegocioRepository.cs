using BeeWeb.Data.Context;
using BeeWeb.Data.Interfaces;
using BeeWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeWeb.Data.Repositories
{
    public class NegocioRepository : Repository<Negocio>, INegocioRepository
    {
        private readonly AppDbContext _appDbContext;
        public NegocioRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Guid> RegistrarAsync(Negocio negocio)//NOTE: ojito aquí para mejorar la regla de negocio a futuro
        {
            await _appDbContext.AddAsync(negocio);
            return negocio.NegocioId;
        }
    }
}
