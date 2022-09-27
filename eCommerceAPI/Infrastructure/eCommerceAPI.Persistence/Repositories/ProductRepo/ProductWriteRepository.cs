using eCommerceAPI.Application.Repositories.ProductRepo;
using eCommerceAPI.Domain.Entities;
using eCommerceAPI.Persistence.Contexts;

namespace eCommerceAPI.Persistence.Repositories.ProductRepo
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
