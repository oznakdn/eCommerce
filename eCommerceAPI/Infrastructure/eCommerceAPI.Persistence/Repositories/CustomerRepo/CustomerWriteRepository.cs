using eCommerceAPI.Application.Repositories.Customer;
using eCommerceAPI.Domain.Entities;
using eCommerceAPI.Persistence.Contexts;

namespace eCommerceAPI.Persistence.Repositories.CustomerRepo
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
