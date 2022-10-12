using eCommerceAPI.Application.UnitOfWork;
using MediatR;

namespace eCommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
    {
        private readonly IQueryUnitOfWork query;

        public GetAllProductsQueryHandler(IQueryUnitOfWork query)
        {
            this.query = query;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = query.productRead.GetAll(false).Select(product => new GetAllProductsQueryResponse
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                CreatedDate = product.CreatedDate.ToShortDateString()
            }).ToList();

            return await Task.FromResult(products);
        }

    }
}
