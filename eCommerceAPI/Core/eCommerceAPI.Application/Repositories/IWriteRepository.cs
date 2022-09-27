using eCommerceAPI.Domain.Entities.Common;

namespace eCommerceAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> CreateRangeAsync(List<T> entities);
        bool Update(T entity);
        Task<bool> DeleteAsync(string id);
        bool Delete(T entity);
        bool DeleteRange(List<T> entities);
        Task<int> SaveAsync();
    }
}
