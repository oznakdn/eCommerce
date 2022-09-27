using eCommerceAPI.Application.Repositories.Customer;
using eCommerceAPI.Application.Repositories.OrderRepo;
using eCommerceAPI.Application.Repositories.ProductRepo;

namespace eCommerceAPI.Application.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ICustomerReadRepository customerRead { get; }
        ICustomerWriteRepository customerWrite { get; }

        IOrderReadRepository orderRead { get; }
        IOrderWriteRepository orderWrite { get; }

        IProductReadRepository productRead { get; }
        IProductWriteRepository productWrite { get; }

        Task<int> SaveAsync();
    }
}
