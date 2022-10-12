using MediatR;

namespace eCommerceAPI.Application.Features.Queries.ProductQueries.GetProductById
{
    public class GetProductByIdQueryRequest:IRequest<GetProductByIdQueryResponse>
    {
        public GetProductByIdQueryRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
