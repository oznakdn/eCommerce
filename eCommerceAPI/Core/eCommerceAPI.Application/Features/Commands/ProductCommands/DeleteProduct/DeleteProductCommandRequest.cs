using MediatR;

namespace eCommerceAPI.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandRequest:IRequest<DeleteProductCommandResponse>
    {
        public DeleteProductCommandRequest(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
