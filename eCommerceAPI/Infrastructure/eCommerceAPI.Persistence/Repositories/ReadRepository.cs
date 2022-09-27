using eCommerceAPI.Application.Repositories;
using eCommerceAPI.Domain.Entities.Common;
using eCommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerceAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        protected readonly eCommerceDbContext _context;

        public ReadRepository(eCommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Entity => _context.Set<T>();

        public IQueryable<T> GetAll(bool isChangeTracking)
        {
            if (!isChangeTracking)
            {
                return Entity.AsNoTracking().AsQueryable();
            }

            return Entity.AsQueryable();
        }

        public IQueryable<T> GetWhere(bool isChangeTracking, Expression<Func<T, bool>> predicate)
        {
            if (!isChangeTracking)
            {
                return Entity.AsNoTracking().Where(predicate).AsQueryable();
            }
            return Entity.Where(predicate).AsQueryable();

        }

        public async Task<T> GetAsync(bool isChangeTracking, Expression<Func<T, bool>> predicate)
        {
            if (!isChangeTracking)
            {
                return await Entity.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
            }
            return await Entity.Where(predicate).FirstOrDefaultAsync();

        }

        public async Task<T> GetByIdAsync(bool isChangeTracking, string id)
        {
            if (!isChangeTracking)
            {
                return await Entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id == Guid.Parse(id));
            }
            return await Entity.FirstOrDefaultAsync(e => e.Id == Guid.Parse(id));

        }
    }
}
