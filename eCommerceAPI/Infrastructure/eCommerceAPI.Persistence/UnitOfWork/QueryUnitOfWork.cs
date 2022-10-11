using eCommerceAPI.Application.Repositories.Customer;
using eCommerceAPI.Application.Repositories.OrderRepo;
using eCommerceAPI.Application.Repositories.ProductRepo;
using eCommerceAPI.Application.UnitOfWork;
using eCommerceAPI.Persistence.Contexts;
using eCommerceAPI.Persistence.Repositories.CustomerRepo;
using eCommerceAPI.Persistence.Repositories.OrderRepo;
using eCommerceAPI.Persistence.Repositories.ProductRepo;

namespace eCommerceAPI.Persistence.UnitOfWork
{
    public class QueryUnitOfWork : IQueryUnitOfWork
    {

        private readonly eCommerceDbContext _context;

        public QueryUnitOfWork(eCommerceDbContext context)
        {
            _context = context;
        }


        private CustomerReadRepository _CustomerRead;
        private OrderReadRepository _OrderRead;
        private ProductReadRepository _ProductRead;


        public ICustomerReadRepository customerRead => _CustomerRead ?? (_CustomerRead = new CustomerReadRepository(_context));

        public IOrderReadRepository orderRead => _OrderRead ?? (_OrderRead = new OrderReadRepository(_context));

        public IProductReadRepository productRead => _ProductRead ?? (_ProductRead = new ProductReadRepository(_context));
    }
}
