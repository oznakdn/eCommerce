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
    public class CommandUnitOfWork : ICommandUnitOfWork
    {

        private readonly eCommerceDbContext _context;

        public CommandUnitOfWork(eCommerceDbContext context)
        {
            _context = context;
        }

        private CustomerWriteRepository _CustomerWrite;
        private OrderWriteRepository _OrderWrite;
        private ProductWriteRepository _ProductWrite;


        public ICustomerWriteRepository customerWrite => _CustomerWrite ?? (_CustomerWrite = new CustomerWriteRepository(_context));

        public IOrderWriteRepository orderWrite => _OrderWrite ?? (_OrderWrite = new OrderWriteRepository(_context));

        public IProductWriteRepository productWrite => _ProductWrite ?? (_ProductWrite = new ProductWriteRepository(_context));

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
