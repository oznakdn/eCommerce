using eCommerceAPI.Application.Repositories.Customer;
using eCommerceAPI.Domain.Entities;
using eCommerceAPI.Persistence.Contexts;

namespace eCommerceAPI.Persistence.Repositories.CustomerRepo
{
    public class CustomerReadRepository : ReadRepository<Customer>,ICustomerReadRepository
    {
        public CustomerReadRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
