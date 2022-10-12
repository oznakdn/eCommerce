using eCommerceAPI.Application.UnitOfWork;
using MediatR;

namespace eCommerceAPI.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly ICommandUnitOfWork command;

        public DeleteProductCommandHandler(ICommandUnitOfWork command)
        {
            this.command = command;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {

            await command.productWrite.DeleteAsync(request.Id);
            await command.SaveAsync();
            return new DeleteProductCommandResponse($"{request.Id} product is deleted successfully");
        }
    }
}
