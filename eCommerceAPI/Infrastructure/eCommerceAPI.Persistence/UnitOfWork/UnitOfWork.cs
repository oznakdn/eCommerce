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
    public class UnitOfWork : IUnitOfWork
    {

        private readonly eCommerceDbContext _context;

        public UnitOfWork(eCommerceDbContext context)
        {
            _context = context;
        }

        private CustomerReadRepository _CustomerRead;
        private CustomerWriteRepository _CustomerWrite;

        private OrderReadRepository _OrderRead;
        private OrderWriteRepository _OrderWrite;

        private ProductReadRepository _ProductRead;
        private ProductWriteRepository _ProductWrite;


        public ICustomerReadRepository customerRead => _CustomerRead ?? (_CustomerRead = new CustomerReadRepository(_context));

        public ICustomerWriteRepository customerWrite => _CustomerWrite ?? (_CustomerWrite = new CustomerWriteRepository(_context));

        public IOrderReadRepository orderRead => _OrderRead ?? (_OrderRead = new OrderReadRepository(_context));

        public IOrderWriteRepository orderWrite => _OrderWrite ?? (_OrderWrite = new OrderWriteRepository(_context));

        public IProductReadRepository productRead => _ProductRead ?? (_ProductRead = new ProductReadRepository(_context));

        public IProductWriteRepository productWrite => _ProductWrite ?? (_ProductWrite = new ProductWriteRepository(_context));

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
