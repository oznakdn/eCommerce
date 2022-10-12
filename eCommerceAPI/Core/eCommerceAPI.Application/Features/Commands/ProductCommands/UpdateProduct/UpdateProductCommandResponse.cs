namespace eCommerceAPI.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandResponse
    {
        public UpdateProductCommandResponse(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
