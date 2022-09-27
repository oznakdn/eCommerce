using eCommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity,new()
    {
        DbSet<T> Entity { get; }

    }
}
