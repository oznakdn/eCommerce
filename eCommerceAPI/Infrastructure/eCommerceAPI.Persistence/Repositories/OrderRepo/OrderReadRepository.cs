using eCommerceAPI.Application.Repositories.OrderRepo;
using eCommerceAPI.Domain.Entities;
using eCommerceAPI.Persistence.Contexts;

namespace eCommerceAPI.Persistence.Repositories.OrderRepo
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
