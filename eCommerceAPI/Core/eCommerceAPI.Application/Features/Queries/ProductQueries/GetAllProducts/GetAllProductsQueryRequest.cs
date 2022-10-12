using MediatR;

namespace eCommerceAPI.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductsQueryRequest:IRequest<List<GetAllProductsQueryResponse>>
    {
    }
}
