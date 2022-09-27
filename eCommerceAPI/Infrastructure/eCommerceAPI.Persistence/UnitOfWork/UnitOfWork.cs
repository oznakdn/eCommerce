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

        private CustomerReadRepository CustomerRead;
        private CustomerWriteRepository CustomerWrite;

        private OrderReadRepository OrderRead;
        private OrderWriteRepository OrderWrite;

        private ProductReadRepository ProductRead;
        private ProductWriteRepository ProductWrite;


        public ICustomerReadRepository customerRead => CustomerRead ?? (CustomerRead = new CustomerReadRepository(_context));

        public ICustomerWriteRepository customerWrite => CustomerWrite ?? (CustomerWrite = new CustomerWriteRepository(_context));

        public IOrderReadRepository orderRead => OrderRead ?? (OrderRead = new OrderReadRepository(_context));

        public IOrderWriteRepository orderWrite => OrderWrite ?? (OrderWrite = new OrderWriteRepository(_context));

        public IProductReadRepository productRead => ProductRead ?? (ProductRead = new ProductReadRepository(_context));

        public IProductWriteRepository productWrite => ProductWrite ?? (ProductWrite = new ProductWriteRepository(_context));

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
