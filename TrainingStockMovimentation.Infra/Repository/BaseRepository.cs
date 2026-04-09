using TrainingStockMovimentation.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TrainingStockMovimentation.Infra.Repository
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context) 
        {
            _context = context;
        }

        public IQueryable<T> GetAllQuery<T>(bool asNoTracking = false) where T : class
        {
            var query = _context.Set<T>().AsQueryable();

            if (asNoTracking)
                query = query.AsNoTracking();

            return query;
        }
    }
}
