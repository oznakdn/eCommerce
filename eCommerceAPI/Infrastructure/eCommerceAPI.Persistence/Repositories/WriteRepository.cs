using eCommerceAPI.Application.Repositories;
using eCommerceAPI.Domain.Entities.Common;
using eCommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCommerceAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        protected readonly eCommerceDbContext _context;

        public WriteRepository(eCommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Entity => _context.Set<T>();

        public async Task<bool> CreateAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Entity.AddAsync(entity);
            return entityEntry.State == EntityState.Added;

        }

        public async Task<bool> CreateRangeAsync(List<T> entities)
        {
            await Entity.AddRangeAsync(entities);
            return true;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var entity = await Entity.FindAsync(Guid.Parse(id));
            EntityEntry<T> entityEntry = Entity.Remove(entity);
            return Delete(entity);
        }

        public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = Entity.Remove(entity);
            return entityEntry.State == EntityState.Deleted;

        }

        public bool DeleteRange(List<T> entities)
        {
            Entity.RemoveRange(entities);
            return true;
        }

        public bool Update(T entity)
        {
            EntityEntry<T> entityEntry = Entity.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
