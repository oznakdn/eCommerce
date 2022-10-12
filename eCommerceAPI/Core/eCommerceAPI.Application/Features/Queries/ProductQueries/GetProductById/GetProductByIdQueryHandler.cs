using eCommerceAPI.Application.UnitOfWork;
using MediatR;

namespace eCommerceAPI.Application.Features.Queries.ProductQueries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly IQueryUnitOfWork query;

        public GetProductByIdQueryHandler(IQueryUnitOfWork query)
        {
            this.query = query;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await query.productRead.GetByIdAsync(false, request.Id);
            if(product!=null)
            {
                return new GetProductByIdQueryResponse
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Stock = product.Stock,
                    CreatedDate = product.CreatedDate.ToShortDateString()
                };
            }

            return new GetProductByIdQueryResponse { ResponseMessage = "Product is not found!" };
            
        }
    }
}
