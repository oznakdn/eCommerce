using eCommerceAPI.Application.Repositories.ProductRepo;
using eCommerceAPI.Domain.Entities;
using eCommerceAPI.Persistence.Contexts;

namespace eCommerceAPI.Persistence.Repositories.ProductRepo
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(eCommerceDbContext context) : base(context)
        {
        }
    }
}
