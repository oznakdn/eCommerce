using eCommerceAPI.Application.Repositories.Customer;
using eCommerceAPI.Application.Repositories.OrderRepo;
using eCommerceAPI.Application.Repositories.ProductRepo;

namespace eCommerceAPI.Application.UnitOfWork
{
    public interface IQueryUnitOfWork
    {
        ICustomerReadRepository customerRead { get; }
        IOrderReadRepository orderRead { get; }
        IProductReadRepository productRead { get; }

    }
}
