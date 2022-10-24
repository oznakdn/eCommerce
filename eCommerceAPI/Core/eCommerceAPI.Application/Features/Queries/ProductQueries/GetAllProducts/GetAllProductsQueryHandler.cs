using eCommerceAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
    {
        private readonly IQueryUnitOfWork query;
        private readonly ILogger<GetAllProductsQueryHandler> logger;

        public GetAllProductsQueryHandler(IQueryUnitOfWork query, ILogger<GetAllProductsQueryHandler> logger)
        {
            this.query = query;
            this.logger = logger;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Products was watched.");
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
