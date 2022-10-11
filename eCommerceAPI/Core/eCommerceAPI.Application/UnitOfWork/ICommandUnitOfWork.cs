using eCommerceAPI.Application.Repositories.Customer;
using eCommerceAPI.Application.Repositories.OrderRepo;
using eCommerceAPI.Application.Repositories.ProductRepo;

namespace eCommerceAPI.Application.UnitOfWork
{
    public interface ICommandUnitOfWork:IAsyncDisposable
    {
        ICustomerWriteRepository customerWrite { get; }
        IOrderWriteRepository orderWrite { get; }
        IProductWriteRepository productWrite { get; }

        Task<int> SaveAsync();

    }
}
