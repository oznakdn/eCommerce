using eCommerceAPI.Application.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace eCommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly ICommandUnitOfWork command;
        private readonly IQueryUnitOfWork query;
        private readonly ILogger<UpdateProductCommandHandler> logger;

        public UpdateProductCommandHandler(ICommandUnitOfWork command, IQueryUnitOfWork query, ILogger<UpdateProductCommandHandler> logger)
        {
            this.command = command;
            this.query = query;
            this.logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await query.productRead.GetByIdAsync(false, request.Id);
            product.ProductName = request.ProductName;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.UpdatedDate = DateTime.UtcNow;

            command.productWrite.Update(product);
            await command.SaveAsync();
            logger.LogInformation("Product was updated.");

            return new UpdateProductCommandResponse($"{product.Id} number product is updated successfully");
                
        }
    }
}
