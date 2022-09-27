using eCommerceAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace eCommerceAPI.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T> where T:BaseEntity,new()
    {
        IQueryable<T> GetAll(bool isChangeTracking);
        IQueryable<T> GetWhere(bool isChangeTracking, Expression<Func<T,bool>>predicate);
        Task<T>GetAsync(bool isChangeTracking, Expression<Func<T,bool>>predicate);
        Task<T> GetByIdAsync(bool isChangeTracking, string id);
    }
}
