using MediatR;

namespace eCommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

    }
}
