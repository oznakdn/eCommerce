namespace eCommerceAPI.Application.Features.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandResponse
    {
        public DeleteProductCommandResponse(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
