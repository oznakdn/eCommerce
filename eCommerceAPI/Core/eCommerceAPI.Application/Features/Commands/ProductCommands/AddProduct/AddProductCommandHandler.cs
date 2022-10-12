using eCommerceAPI.Application.UnitOfWork;
using eCommerceAPI.Domain.Entities;
using MediatR;

namespace eCommerceAPI.Application.Features.Commands.ProductCommands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        private readonly ICommandUnitOfWork command;

        public AddProductCommandHandler(ICommandUnitOfWork command)
        {
            this.command = command;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = new()
            {
                ProductName = request.ProductName,
                Price = request.Price,
                Stock = request.Stock,
                CreatedDate = DateTime.UtcNow
            };
            await command.productWrite.CreateAsync(product);
            await command.SaveAsync();

            return new AddProductCommandResponse($"{product.ProductName} is created successfully");
        }
    }
}
