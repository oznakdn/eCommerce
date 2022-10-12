using MediatR;

namespace eCommerceAPI.Application.Features.Commands.ProductCommands.AddProduct
{
    public class AddProductCommandRequest:IRequest<AddProductCommandResponse>
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
