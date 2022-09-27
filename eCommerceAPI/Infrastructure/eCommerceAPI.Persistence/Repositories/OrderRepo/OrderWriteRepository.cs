using eCommerceAPI.Application.Repositories.OrderRepo;
using eCommerceAPI.Domain.Entities;
using eCommerceAPI.Persistence.Contexts;

namespace eCommerceAPI.Persistence.Repositories.OrderRepo
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
